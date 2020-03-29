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
using Microsoft.AspNetCore.Mvc.Formatters;
using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;

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
        readonly IRepository<Location> _locationRepository;
        readonly projectadContext _dbContext;


        public ArtisanController(IRepository<Artisan> oniswOwoRepository, IRepository<Services> serviceRepository, IRepository<Projects> projectRepository, IRepository<Quote> quoteRepository, IRepository<Booking> bookingRepository, IRepository<Gallary> galleryRepository, IRepository<PaymentHistory> paymentHistoryRepository, projectadContext dbContext, IRepository<Location> locationRepository)
        {
            _artisanRepository = oniswOwoRepository;
            _serviceRepository = serviceRepository;
            _projectRepository = projectRepository;
            _quoteRepository = quoteRepository;
            _bookingRepository = bookingRepository;
            _galleryRepository = galleryRepository;
            _paymentHistoryRepository = paymentHistoryRepository;
            _dbContext = dbContext;
            _locationRepository = locationRepository;
        }

        // GET: api/OniseOwo
        // [Route("[action]")]
        [HttpGet(ApiRoute.Artisan.GetAll)]
        public async Task<IActionResult> AwonOniseOwo()
        {
            //IEnumerable<Artisan> awonOnibara = await _artisanRepository.GetAllAsync();

            //if (awonOnibara != null)
            //    return Ok(new { status = HttpStatusCode.OK, message = awonOnibara });
            //return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });

            IEnumerable<Artisan> AllArtisans = await _artisanRepository.GetAllAsync();

            if (AllArtisans.Any())
            {
                List<ArtisanResponse> _allArtisan = AllArtisans.Select(x => new ArtisanResponse
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserId = x.UserId,
                    PhoneNumber = x.PhoneNumber,
                    IdcardNo = x.IdcardNo,
                    PicturePath = x.PicturePath,
                    Address = x.Address,
                    Category = x.ArtisanCategory.CategoryName,
                    State = x.State,
                    AboutMe = x.AboutMe,
                    CreatedDate = x.CreatedDate,
                    AreaLocation = x.AreaLocation.Area
                }).ToList();
                return Ok(new { status = HttpStatusCode.OK, message = _allArtisan });
            }
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

            ArtisanResponse _allArtisan = new ArtisanResponse
            {
                Id = thisArtsan.Id,
                FirstName = thisArtsan.FirstName,
                LastName = thisArtsan.LastName,
                UserId = thisArtsan.UserId,
                PhoneNumber = thisArtsan.PhoneNumber,
                IdcardNo = thisArtsan.IdcardNo,
                PicturePath = thisArtsan.PicturePath,
                Address = thisArtsan.Address,
                Category = thisArtsan.ArtisanCategory.CategoryName,
                State = thisArtsan.State,
                AboutMe = thisArtsan.AboutMe,
                CreatedDate = thisArtsan.CreatedDate,
                AreaLocation = thisArtsan.AreaLocation.Area
            };
            return Ok(new { status = HttpStatusCode.OK, Message = _allArtisan });
        }

        // POST: api/OniseOwo
        [HttpPost(ApiRoute.Artisan.Create)]
        [Produces("application/json")]
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
                UserId = model.UserId,
                CreatedDate = DateTime.Now
            };
            Artisan kooniseOwoTuntun = await _artisanRepository.CreateAsync(newArtisan);
            return CreatedAtAction(nameof(ThisArtisan), new { id = newArtisan.Id }, new { status = HttpStatusCode.Created, message = kooniseOwoTuntun });
        }

        //PUT: api/OniseOwo/5
        [HttpPut(ApiRoute.Artisan.Update)]
        public async Task<IActionResult> Put(int id, [FromBody] UserProfileRequest model)
        {
            Artisan thisArtisan = await _artisanRepository.GetByIdAsync(id);

            if (thisArtisan == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "This Artisan was not found" });

            thisArtisan.FirstName = model.FirstName;
            thisArtisan.LastName = model.LastName;
            thisArtisan.PhoneNumber = model.PhoneNumber;
            thisArtisan.IdcardNo = model.IdcardNo;
            thisArtisan.PicturePath = model.PicturePath;
            thisArtisan.Address = model.Address;
            thisArtisan.State = model.State;
            thisArtisan.ArtisanCategoryId = model.ArtisanCategoryId;
            thisArtisan.AreaLocationId = model.AreaLocationId;
            thisArtisan.AboutMe = model.AboutMe;

            await _artisanRepository.UpdateAsync(thisArtisan);

            ArtisanResponse artisanUpdateResponse = new ArtisanResponse
            {
                Id = thisArtisan.Id,
                FirstName = thisArtisan.FirstName,
                LastName = thisArtisan.LastName,
                UserId = thisArtisan.UserId,
                PhoneNumber = thisArtisan.PhoneNumber,
                IdcardNo = thisArtisan.IdcardNo,
                PicturePath = thisArtisan.PicturePath,
                Address = thisArtisan.Address,
                Category = thisArtisan.ArtisanCategory.CategoryName,
                State = thisArtisan.State,
                AboutMe = thisArtisan.AboutMe,
                CreatedDate = thisArtisan.CreatedDate,
                AreaLocation = thisArtisan.AreaLocation.Area
            };
            return Ok(new { status = HttpStatusCode.OK, message = artisanUpdateResponse });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete(ApiRoute.Artisan.Delete)]
        //public void Delete(int id)
        //{
        //}
    }
}
