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
using Microsoft.EntityFrameworkCore;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers.V1
{
    [ApiVersion("1", Deprecated = true)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServiceController : ControllerBase
    {
        readonly IRepository<Services> _serviceRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;

        public ServiceController(IRepository<Services> serviceRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository)
        {
            _serviceRepository = serviceRepository;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
        }

        // GET: api/Service
        [HttpGet(ApiRoute.Service.GetAll)]
        public async Task<IActionResult> AllService()
        {
            IEnumerable<Services> AllArticle = await _serviceRepository.GetAllAsync();

            if (AllArticle.Any())
                return Ok(new { status = HttpStatusCode.OK, message = AllArticle });
            return NoContent();
        }

        // GET: api/Service/5
        [HttpGet(ApiRoute.Service.Get)]
        public async Task<IActionResult> ThisService(int id)
        {
            Services thisService = await _serviceRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (thisService == null)
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "The requested service may have been discontinued by the Artisan" });

            Artisan thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                var getArtisan = result.Result.SingleOrDefault(x => x.Id == thisService.ArtisanId);
                return getArtisan;
            });

            thisService.Artisan = thisArtisan;

            return Ok(new { status = HttpStatusCode.OK, Message = thisService });
        }

        // POST: api/Service
        [HttpPost(ApiRoute.Service.Create)]
        public async Task<IActionResult> Post([FromBody] ServiceRequest model)
        {

            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            UserLogin getUser = await _userLoginRepository.GetByAsync(x => x.Id.Equals(model.UserId)).FirstOrDefaultAsync();
            int? userStatus = getUser?.StatusId;

            if (getUser == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid user id entered" });
            }

            if(userStatus.Value != (int)AppStatus.Active) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user has been suspended, please contact the administrator" });

            Artisan thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.UserId.Equals(getUser.Id));
            });

            if (thisArtisan == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "No artisan profile exist for the user id entered" });

            Services newServie = new Services
            {
                ArtisanId = thisArtisan.Id,
                ServiceName = model.ServiceName,
                StatusId = (int) AppStatus.Active,
                Descriptions = model.Descriptions,
                CreationDate = DateTime.Now
            };

           var newService = await _serviceRepository.CreateAsync(newServie);
            var serviceCreated = new { ArtisanId = newService.Id, ServiceName = newService.ServiceName, StatusId = newService.StatusId, Description = newService.Descriptions };

            return CreatedAtAction("ThisService", new { id = newServie.Id }, new { status = HttpStatusCode.Created, message = serviceCreated });
        }

       // PUT: api/Service/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ServiceRequest model)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
