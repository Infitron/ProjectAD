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
using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers
{
    // [Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArtisanController : ControllerBase
    {
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<Services> _serviceRepository;
        readonly IRepository<Projects> _projectRepository;
        readonly IRepository<Quote> _quoteRepository;
        readonly IRepository<Booking> _bookingRepository;
        readonly IRepository<Gallary> _galleryRepository;
        readonly IRepository<PaymentHistory> _paymentHistoryRepository;


        public ArtisanController(IRepository<Artisan> oniswOwoRepository, IRepository<Services> serviceRepository, IRepository<Projects> projectRepository, IRepository<Quote> quoteRepository, IRepository<Booking> bookingRepository, IRepository<Gallary> galleryRepository, IRepository<PaymentHistory> paymentHistoryRepository)
        {
            _artisanRepository = oniswOwoRepository;
            _serviceRepository = serviceRepository;
            _projectRepository = projectRepository;
            _quoteRepository = quoteRepository;
            _bookingRepository = bookingRepository;
            _galleryRepository = galleryRepository;
            _paymentHistoryRepository = paymentHistoryRepository;
        }

        // GET: api/OniseOwo
        // [Route("[action]")]
        [HttpGet(ApiRoute.Artisan.GetAll)]
        public async Task<IActionResult> AwonOniseOwo()
        {
            IEnumerable<Artisan> awonOnibara = await _artisanRepository.GetAllAsync();

            if (awonOnibara != null)
                return Ok(new { status = HttpStatusCode.OK, message = awonOnibara });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/OniseOwo/5
        //[Route("[action]/{id}")]
        [HttpGet(ApiRoute.Artisan.Get)]
        public async Task<IActionResult> ThisArtisan(int id = 0)
        {
            if (id == 0)
                return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "Artisan ID was not supplied" });

            Artisan thisArtsan = await _artisanRepository.GetByIdAsync(id);
            

            if (thisArtsan == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "We could not find the artisan you requested" });

            List<Quote> allQuoteRaised = await _quoteRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId.Equals(thisArtsan.Id)).ToList();
            });

            List<Services> allMyServices = await _serviceRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId.Equals(thisArtsan.Id)).ToList();
            });

            List<Booking> allMyBooking = await _bookingRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId.Equals(thisArtsan.Id)).ToList();
            });

            List<Gallary> myGallery = await _galleryRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId.Equals(thisArtsan.Id)).ToList();
            });

            List<PaymentHistory> allMyPaymentHistory = await _paymentHistoryRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId.Equals(thisArtsan.Id)).ToList();
            });

            List<Projects> allMyProjectDone = await _projectRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId.Equals(thisArtsan.Id)).ToList();
            });

            thisArtsan.Services = allMyServices.Count() > 0 ? allMyServices :  new List<Services> {
                new Services { Id = 0, ServiceName = "N/A", ArtisanId = 0, Descriptions = "Not available", CreationDate = DateTime.Now, StatusId = 0 }
            };

            thisArtsan.Gallary = myGallery.Count() > 0 ? myGallery :  new List<Gallary> {
                new Gallary { Id = 0, ArtisanId = 0, CreatedDate = DateTime.Now, Descr = "Not available", JobDate = DateTime.Now, JobName = "Not available", PicturePath = "Not available" }
            };
            thisArtsan.Booking = allMyBooking.Count() > 0 ? allMyBooking : new List<Booking> {
                new Booking { Id = 0, ArtisanId = 0, ClienId = 0, CreatedDate  = DateTime.Now, Messages = "Not available", MsgDate = DateTime.Now, MsgTime = DateTime.Now.TimeOfDay, ServiceId = 0, QuoteId = 0}
            };
            thisArtsan.PaymentHistory = allMyPaymentHistory.Count() > 0 ? allMyPaymentHistory:  new List<PaymentHistory> {
                new PaymentHistory{ Id = 0, AmountPaid = 0.00M, ArtisanId = 0, ClientId = 0, CreatedDate = DateTime.Now, PayDate = DateTime.Now, PaymentType = "Not available", ProjectId = 0 }
            };
            thisArtsan.Projects = allMyProjectDone.Count() > 0 ? allMyProjectDone : new List<Projects> {
                new Projects { Id = 0, ArtisanId = 0, ClientId = 0, CreationDate =DateTime.Now} };

            return Ok(new { status = HttpStatusCode.OK, Message = thisArtsan });
        }

        // POST: api/OniseOwo
        [HttpPost(ApiRoute.Artisan.Create)]
        public async Task<IActionResult> Post([FromBody] UserProfileRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artisan newArtisan = new Artisan
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                IdcardNo = model.IdcardNo,
                PicturePath = model.PicturePath,
                Address = model.Address,
                State = model.State,
                ArtisanCategoryId = model.ArtisanCategoryId,
                AreaLocationId = model.AreaLocationId,                
                AboutMe = model.AboutMe,
                UserId  = model.UserId                
            };
            Artisan kooniseOwoTuntun = await _artisanRepository.CreateAsync(newArtisan);
            return CreatedAtAction(nameof(ThisArtisan), new { id = newArtisan.Id }, new { status = HttpStatusCode.Created, message = kooniseOwoTuntun });           
        }

        // PUT: api/OniseOwo/5
        //[HttpPut(ApiRoute.Artisan.Update)]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete(ApiRoute.Artisan.Delete)]
        //public void Delete(int id)
        //{
        //}
    }
}
