using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.ApiConfig;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;
using Swashbuckle.AspNetCore.Annotations;
using static EncryptionService.AES;

namespace ProjectADApi.Controllers.V2
{
    //[Route("api/[controller]")]
    [ApiVersion("1.1")]
    [SwaggerTag("The version controller version 1.1. This include all endpoint of version the update endpoint.")]       
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServiceController : ControllerBase
    {
        readonly IRepository<Services> _serviceRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;
        readonly FlutterRaveConf _flutterRaveConf;

        public ServiceController(IRepository<Services> serviceRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository, FlutterRaveConf flutterRaveConf)
        {
            _serviceRepository = serviceRepository;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
            _flutterRaveConf = flutterRaveConf;
        }

        // GET: api/Service
        [HttpGet(ApiRoute.Service.GetAll)]
        public async Task<IActionResult> AllService()
        {
            IEnumerable<Services> AllArticle = await _serviceRepository.GetAllAsync();

            if (AllArticle.Any())
            {
                List<ServiceResponse> services = AllArticle.Select(x =>
                new ServiceResponse
                {
                    Id = x.Id,
                    ArtisanId = x.ArtisanId,
                    ServiceName = x.ServiceName,
                    StatusId = x.StatusId,
                    CreationDate = x.CreationDate,
                    Descriptions = x.Descriptions
                }
                ).ToList();

                return Ok(new { status = HttpStatusCode.OK, message = services });

            }
            return NoContent();
        }

        // GET: api/Service/5
        [HttpGet(ApiRoute.Service.Get)]
        public async Task<IActionResult> ThisService(int id)
        {
           // string rawUrlString = HttpUtility.UrlDecode(id);
           //var decryptId = int.Parse(Decrypt(rawUrlString, _flutterRaveConf.EncryptionKey));
            Services getThisService = await _serviceRepository.GetByIdAsync(id);

            if (getThisService == null)
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "The requested service may have been discontinued by the Artisan" });

            ServiceResponse thisService = new ServiceResponse
            {
                Id = getThisService.Id,
                ArtisanId = getThisService.ArtisanId,
                ServiceName = getThisService.ServiceName,
                StatusId = getThisService.StatusId,
                CreationDate = getThisService.CreationDate,
                Descriptions = getThisService.Descriptions
            };

            return Ok(new { status = HttpStatusCode.OK, message = thisService });
        }

        // POST: api/Service
        [HttpPost(ApiRoute.Service.Create)]
        public async Task<IActionResult> Post([FromBody] ServiceRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });


            //int decryptId = int.Parse(Decrypt(model.ArtisanId, _flutterRaveConf.EncryptionKey));

            //if (model.UserId == 0) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user has been suspended, please contact the administrator" });

            UserLogin getUser = await _userLoginRepository.GetByIdAsync(model.UserId);
            int? userStatus = getUser?.StatusId;

            if (getUser == null)BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user does not exist on the platform" });


            if (userStatus.Value != (int)AppStatus.Active) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user has been suspended, please contact the administrator" });

            Artisan thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.UserId.Equals(getUser.Id));
            });

            //if (thisArtisan == null)
            //    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "No artisan profile exist for the user id entered" });

            Services newServie = new Services
            {
                ArtisanId = thisArtisan.Id,
                ServiceName = model.ServiceName,
                StatusId = (int)AppStatus.Active,
                Descriptions = model.Descriptions,
                CreationDate = DateTime.Now
            };

            var newService = await _serviceRepository.CreateAsync(newServie);
            var serviceCreated = new { ArtisanId = newService.Id, ServiceName = newService.ServiceName, StatusId = newService.StatusId, Description = newService.Descriptions };

            return CreatedAtAction("ThisService", new { id = newServie.Id }, new { status = HttpStatusCode.Created, message = serviceCreated });
        }

        // PUT: api/Service/5
        [HttpPut(ApiRoute.Service.Update)]
        public async Task<IActionResult> Put([FromBody] ServiceResponse model)
        {
            //var decryptId = int.Parse(Decrypt(id, _flutterRaveConf.EncryptionKey));
            Services thisService = await _serviceRepository.GetByIdAsync(model.Id);

            if (thisService == null)
            {
                return BadRequest();
            }

            
            thisService.Descriptions = model.Descriptions;
            thisService.ServiceName = model.ServiceName;
            thisService.StatusId = model.StatusId;

            thisService = await _serviceRepository.UpdateAsync(thisService);

            ServiceResponse serviceUpdateResponse = new ServiceResponse { Id = thisService.Id, ArtisanId = thisService.ArtisanId, Descriptions = thisService.Descriptions, ServiceName = thisService.ServiceName };
            return Ok(new { status = HttpStatusCode.BadRequest, message = serviceUpdateResponse });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
