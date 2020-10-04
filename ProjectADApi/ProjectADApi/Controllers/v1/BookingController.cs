using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Controllers.V1.Contracts.Response;
//using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers
{
    [ApiVersion("1", Deprecated =true)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookingController : ControllerBase
    {
        readonly IRepository<Booking> _bookingRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;
        readonly IRepository<Client> _clientRepository;
        readonly IRepository<Services> _serviceRepository;

        public BookingController(IRepository<Booking> bookingRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository, IRepository<Client> clientRepository, IRepository<Services> serviceRepository)
        {
            _bookingRepository = bookingRepository;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
            _clientRepository = clientRepository;
            _serviceRepository = serviceRepository;
        }

        // GET: api/Booking

        [HttpGet(ApiRoute.Order.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var allBooking = await _bookingRepository.GetAllAsync();

            if (allBooking != null)
            {
                List<V1.Contracts.Response.BookingResponse> allBookingResponse = allBooking.Select(x =>
                new V1.Contracts.Response.BookingResponse
                {
                    Id = x.Id,
                    ArtisanId = x.ArtisanId,
                    ClientId = x.ClienId,
                    ArtisanFullName = $"{x.Artisan.FirstName ?? string.Empty} {x.Artisan.LastName ?? string.Empty}",
                    ClientFullName = $"{x.Clien.FirstName ?? string.Empty} {x.Clien.LastName ?? string.Empty}",
                    Messages = x.Messages,
                    MsgTime = x.MsgTime,
                    MsgDate = x.MsgDate,
                    CreatedDate = x.CreatedDate,
                    ServiceId = x.Id,
                    QuoteId = x.QuoteId

                }).ToList();
                return Ok( new { status = HttpStatusCode.OK, message = allBookingResponse });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        //GET: api/Booking/5        
        [HttpGet(ApiRoute.Order.Get)]
        public async Task<IActionResult> ThisService(int id)
        {
            Booking getBooking = await _bookingRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (getBooking != null)
            {
                BookingResponse thisBooking = new BookingResponse
                {
                    Id = getBooking.Id,
                    ArtisanId = getBooking.ArtisanId,
                    ClientId = getBooking.ClienId,
                    ArtisanFullName = $"{getBooking.Artisan.FirstName ?? string.Empty} {getBooking.Artisan?.LastName ?? string.Empty}",
                    ClientFullName = $"{getBooking.Clien.FirstName ?? string.Empty} {getBooking.Clien.LastName ?? string.Empty}",
                    Messages = getBooking.Messages,
                    MsgTime = getBooking.MsgTime,
                    MsgDate = getBooking.MsgDate,
                    CreatedDate = getBooking.CreatedDate,
                    ServiceId = getBooking.Id,
                    QuoteId = getBooking.QuoteId
                };
                return Ok(new { status = HttpStatusCode.OK, Message = thisBooking });
            }
            return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "Wrond booking id supplied" });
        }

        // POST: api/Booking
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(StatusCodes))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost(ApiRoute.Order.Create)]
        public async Task<IActionResult> Post([FromBody] BookingRequest model)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            Services thisService = await _serviceRepository.GetByAsync(x => x.Id.Equals(model.ServiceId)).FirstOrDefaultAsync();

            UserLogin getThisClientUser = await _userLoginRepository.GetByAsync(x => x.Id.Equals(model.ClientUserId)).FirstOrDefaultAsync();

            var allClient = await _clientRepository.GetAllAsync();

            Client getThisClient = allClient.SingleOrDefault(x => x.UserId.Equals(getThisClientUser.Id));

            if (getThisClient == null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Client do not have Client Profile yet" });

            Artisan thisArtisan = await _artisanRepository.GetByAsync(x => x.Id.Equals(thisService.ArtisanId)).FirstOrDefaultAsync();
            UserLogin getThisArtisanUserStatus = null;

            if (thisArtisan != null)
            {
                getThisArtisanUserStatus = await _userLoginRepository.GetByAsync(x => x.Id.Equals(thisArtisan.UserId)).FirstOrDefaultAsync();
            }

            if (getThisArtisanUserStatus.StatusId != (int)AppStatus.Active) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "We can not proceed with your booking, the artisan is not active on the platform" });

            Booking newRequest = new Booking
            {
                ArtisanId = thisService.ArtisanId,
                ClienId = getThisClient.Id,
                Messages = model.Messages,
                ServiceId = model.ServiceId,
                MsgDate = DateTime.Now,
                MsgTime = DateTime.Now.TimeOfDay,
                CreatedDate = DateTime.Now
            };

            await _bookingRepository.CreateAsync(newRequest);
            var cratedObj = new { ArtisanId = newRequest.ArtisanId, ClientId = newRequest.ClienId, Message = newRequest.Messages, ServiceId = newRequest.ServiceId, MessageDate = newRequest.MsgDate, MessageTime = newRequest.MsgTime, CreatedDate = newRequest.CreatedDate };

            return CreatedAtAction("ThisService", new { id = newRequest.Id }, new { status = HttpStatusCode.Created, message = cratedObj });
        }

        // PUT: api/Booking/5
        [Produces("application/json")]
        // [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut(ApiRoute.Order.Update)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookingRequest model)
        {
            if (!ModelState.IsValid) BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Booking getThisBooking = await _bookingRepository.GetByAsync(x => x.Id.Equals(model.BookingId)).FirstOrDefaultAsync();

            if (getThisBooking == null) return NotFound(new { status = HttpStatusCode.NotFound, message = "We could not find the booking requested" });

            getThisBooking.QuoteId = model.QouteId;
            await _bookingRepository.UpdateAsync(getThisBooking);

            var cratedObj = new { ArtisanId = getThisBooking.ArtisanId, ClientId = getThisBooking.ClienId, Message = getThisBooking.Messages, ServiceId = getThisBooking.ServiceId, MessageDate = getThisBooking.MsgDate, MessageTime = getThisBooking.MsgTime, CreatedDate = getThisBooking.CreatedDate };

            return Ok(new { status = HttpStatusCode.OK, message = cratedObj });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete(ApiRoute.Order.Delete)]
        //public void Delete(int id)
        //{
        //}
    }
}
