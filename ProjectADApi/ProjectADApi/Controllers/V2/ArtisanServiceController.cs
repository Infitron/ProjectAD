using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectADApi.ApiConfig;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiVersion("1.1")]
    //[SwaggerTag("This is the version 1.1 of the Account endpoints. Forget password and reset password are delibrately left out from this version. Activating and Suspending a user have been include in the version. We advice to use the this version of the account to update the user activation and suspension")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArtisanServiceController : ControllerBase
    {
        readonly IRepository<ArtisanServices> _artisanServiceRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;
        //readonly FlutterRaveConf _flutterRaveConf;

        private readonly IMapper _mapper;
        projectadContext _dbontext;

        public ArtisanServiceController(IRepository<ArtisanServices> artisanServiceRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository, projectadContext BbContext, IMapper mapper)
        {
            _artisanServiceRepository = artisanServiceRepository;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
            _dbontext = BbContext;
            _mapper = mapper;
        }


        // GET: api/ArtisanService
        [HttpGet(ApiRoute.ArtisanService.GetAll)]
        public async Task<IActionResult> GetAll(int ArtisantId)
        {
            //IEnumerable<ArtisanServices> allArtisanService = await _artisanServiceRepository.GetAllAsync();


            List<ArtisanServiceResponse> myArtisanService = _mapper.Map<List<ArtisanServiceResponse>>(
                await _dbontext.ArtisanServices.Select(x =>
                new ArtisanServiceResponse
                {
                    Id = x.Id,
                    ArtisanId = x.ArtisanId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status,
                    Createdon = x.Createdon,
                    Artisan = new Artisan
                    {
                        FirstName = x.Artisan.FirstName,
                        LastName = x.Artisan.LastName,
                        UserId = x.Artisan.UserId,
                        Address = x.Artisan.Address,
                        AboutMe = x.Artisan.AboutMe,
                        IdcardNo = x.Artisan.IdcardNo,
                        PhoneNumber = x.Artisan.PhoneNumber
                    }
                }).Where(x => x.ArtisanId == ArtisantId).ToListAsync());

            //List<ArtisanServiceResponse> myArtisanService = _mapper.Map<List<ArtisanServiceResponse>>(
            //    await _dbontext.ArtisanServices
            //    .Where(x => x.ArtisanId == ArtisantId)
            //    .ToListAsync());


            if (myArtisanService.Any()) return Ok(new { status = HttpStatusCode.OK, message = myArtisanService });

            return NotFound();
        }

        // GET: api/ArtisanService/5
        [HttpGet]
        [Route(ApiRoute.ArtisanService.GetThisArtisanService)]
        public async Task<IActionResult> ThisArtisanService(int ArtisanServiceId)
        {
            ArtisanServiceResponse getThisService = _mapper.Map<ArtisanServiceResponse>(await _artisanServiceRepository.GetByAsync(x => x.Id.Equals(ArtisanServiceId)).FirstOrDefaultAsync());

            if (getThisService == null)
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "The requested service may have been discontinued by the Artisan" });

            ArtisanServiceResponse thisService = _mapper.Map<ArtisanServiceResponse>(getThisService);
            thisService.Artisan = new Artisan
            {
                FirstName = thisService.Artisan.FirstName,
                LastName = thisService.Artisan.LastName,
                UserId = thisService.Artisan.UserId,
                Address = thisService.Artisan.Address,
                AboutMe = thisService.Artisan.AboutMe,
                IdcardNo = thisService.Artisan.IdcardNo,
                PhoneNumber = thisService.Artisan.PhoneNumber
            };

            return Ok(new { status = HttpStatusCode.OK, message = thisService });
        }

        // POST: api/ArtisanService
        [HttpPost(ApiRoute.ArtisanService.Create)]
        public async Task<IActionResult> Post([FromBody] ArtisanServiceRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var artisan = await _artisanRepository.GetByAsync(x => x.Id.Equals(model.ArtisanId)).FirstOrDefaultAsync();

            if (artisan == null) return BadRequest(new { status = HttpStatusCode.OK, message = "This artisan does not exist" });

            UserLogin userLogin = await _userLoginRepository.GetByAsync(x => x.Id.Equals(artisan.UserId)).FirstOrDefaultAsync();

            if (userLogin == null || userLogin.StatusId != (int)AppStatus.Active) return BadRequest(new { status = HttpStatusCode.OK, message = "This user does not exist or suspended" });

            ArtisanServices newArtisanService = _mapper.Map<ArtisanServices>(model);

            newArtisanService = await _artisanServiceRepository.CreateAsync(newArtisanService);
            return CreatedAtAction(nameof(ThisArtisanService), new { ArtisanServiceId = newArtisanService.Id }, new { status = HttpStatusCode.Created, message = newArtisanService });

        }

        // PUT: api/ArtisanService/5
        [HttpPut(ApiRoute.ArtisanService.Create)]
        public async Task<IActionResult> Put(int id, [FromBody] ArtisanServiceRequest model)
        {
            var artisan = await _artisanRepository.GetByAsync(x => x.Id.Equals(model.ArtisanId)).FirstOrDefaultAsync();

            if (artisan == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "This Artisan was not found" });
           
            UserLogin userLogin = await _userLoginRepository.GetByAsync(x => x.Id.Equals(artisan.UserId)).FirstOrDefaultAsync();

            if (userLogin.StatusId != (int)AppStatus.Active) return BadRequest(new { status = HttpStatusCode.OK, message = "This user does not exist or suspended" });
            
            var updateService = _mapper.Map<ArtisanServices>(model);

            var isUpdateService = await _artisanServiceRepository.UpdateAsync(updateService);

            var response = _mapper.Map<ArtisanServiceResponse>(isUpdateService);
            response.Artisan = new Artisan
            {
                FirstName = response.Artisan.FirstName,
                LastName = response.Artisan.LastName,
                UserId = response.Artisan.UserId,
                Address = response.Artisan.Address,
                AboutMe = response.Artisan.AboutMe,
                IdcardNo = response.Artisan.IdcardNo,
                PhoneNumber = response.Artisan.PhoneNumber
            };

            return Ok(new { status = HttpStatusCode.OK, message = response });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
