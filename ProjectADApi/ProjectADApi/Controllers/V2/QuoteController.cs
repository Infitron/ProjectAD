using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.Controllers.V2.Contract;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.ApiConfig;
using Newtonsoft.Json;
using ProjectADApi.Controllers.V2.Contract.Response;
using ProjectADApi.Model;
using AutoMapper;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuoteController : ControllerBase
    {
        readonly IRepository<Quote> _quoteRepository;
        readonly IRepository<Projects> _projectRepository;
        readonly IRepository<Booking> _bookingRepository;
        readonly IRepository<Services> _serviceRepository;
        readonly AppVariable _appVariable;
        readonly IMapper _mapper;

        public QuoteController(IRepository<Quote> quoteRepository, IRepository<Projects> projectRepository, IRepository<Booking> bookingRepository, IRepository<Services> serviceRepository, IMapper mapper, AppVariable appVariable)
        {
            _quoteRepository = quoteRepository;
            _projectRepository = projectRepository;
            _bookingRepository = bookingRepository;
            _serviceRepository = serviceRepository;
            _appVariable = appVariable;
            _mapper = mapper;
        }


        /// <summary>Gets all Qoutes submitted for various projects </summary>
        /// 
        // GET: api/Article
        // GET: api/Quote
        //[HttpGet(ApiRoute.Quote.GetAll)]
        //public async Task<IActionResult> Get()
        //{
        //    IEnumerable<Quote> AllArticle = await _quoteRepository.GetAllAsync();
        //    if (AllArticle.Any())
        //        return Ok(AllArticle);
        //    return NoContent();
        //}

        // GET: api/Quote/5
        [HttpGet(ApiRoute.Quote.Get)]
        public async Task<IActionResult> ThisQuote(int BookingId)
        {
            var getQuotes = await _quoteRepository.GetAllAsync().Result.Where(x => x.BookingId == BookingId).ToListAsync();
            
            if (getQuotes != null)
            {
                var response = _mapper.Map<List<QuoteResponse>>(getQuotes);
                return Ok(new { status = HttpStatusCode.OK, message = response });
            }
                
            return NotFound(new { status = HttpStatusCode.NotFound, message = "Quote not found" });
        }

        // POST: api/Quote
        [HttpPost(ApiRoute.Quote.Create)]
        public async Task<IActionResult> Post([FromBody] QuoteRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Booking getQuoteBooking = await _bookingRepository.GetByAsync(x => x.Id.Equals(model.BookingId)).FirstOrDefaultAsync();
            int? serviceId = getQuoteBooking?.ServiceId.Value ?? 0;

            if (serviceId == 0)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "None existence Service, Quote cannot be raised" });
            }

            Services getServiceBooking = await _serviceRepository.GetByAsync(x => x.Id.Equals(serviceId.Value)).FirstOrDefaultAsync();
            Quote newQuote = _mapper.Map<Quote>(model);           
            newQuote.OrderStatusId = (int)AppStatus.Initiated;          

            var created = await _quoteRepository.CreateAsync(newQuote);

            QuoteResponse response = _mapper.Map<QuoteResponse>(created);
            
            getQuoteBooking.QuoteId = response.Id;
            await _bookingRepository.UpdateAsync(getQuoteBooking);           

            return CreatedAtAction(nameof(ThisQuote), new { id = newQuote.Id }, new { status = HttpStatusCode.Created, message = response });
        }

        // PUT: api/Quote/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuoteRequestUpdate model)
        {
            Quote getQuote = await _quoteRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            var getQuoteBooking = await _bookingRepository.GetByAsync(x => x.Id.Equals(getQuote.BookingId)).FirstOrDefaultAsync();

            if (getQuote == null)
            {
                getQuote.BookingId = model.BookingId;
                getQuote.Item = JsonConvert.SerializeObject(model.Item);
                getQuote.OrderStatusId = model.OrderStatusId;
                //getQuote.QuoteStatusId = model.QuoteStatusId;

                await _quoteRepository.UpdateAsync(getQuote);
                QuoteResponse response = new QuoteResponse
                {
                    Id = getQuote.Id,
                    //Client = $"{getQuoteBooking.Clien.FirstName} {getQuoteBooking.Clien.FirstName}",
                    //Artisan = $"{getQuoteBooking.Artisan.FirstName} {getQuoteBooking.Artisan.LastName}",
                    Item = JsonConvert.DeserializeObject<List<QuoteItem>>(getQuote.Item),
                    //Address1 = getQuote.Address1,
                    BookingId = getQuote.BookingId,
                    OrderDate = getQuote.OrderDate,
                    //OrderStatus = Enum.GetName(typeof(AppStatus), getQuote.OrderStatusId),
                    //QuoteStatus = Enum.GetName(typeof(AppStatus), getQuote.QuoteStatusId),
                    Vat = getQuote.Vat

                };

                if(getQuoteBooking.QuoteId == null)
                {
                    getQuoteBooking.QuoteId = getQuote.Id;
                    await _bookingRepository.UpdateAsync(getQuoteBooking);
                }

                return Ok(new { status = HttpStatusCode.Created, message = response });

            }
            return NotFound(new { status = HttpStatusCode.Created, message = "Quote not found" });

        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
