using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Authorize]
    public class ServiceController : ControllerBase
    {
        readonly IRepository<Services> _serviceRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;
        readonly IRepository<ArtisanSubCategory> _subCatRepository;
        readonly IRepository<Lga> _lgaRepository;
        readonly FlutterRaveConf _flutterRaveConf;
        readonly bluechub_ProjectADContext dbContext;
        readonly IMapper _mapper;



        public ServiceController(IRepository<Services> serviceRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository, FlutterRaveConf flutterRaveConf, bluechub_ProjectADContext BbContext, IMapper mapper, IRepository<ArtisanSubCategory> subCatRepository, IRepository<Lga> lgaRepository)
        {
            _serviceRepository = serviceRepository;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
            _flutterRaveConf = flutterRaveConf;
            _subCatRepository = subCatRepository;
            _lgaRepository = lgaRepository;
            dbContext = BbContext;
            _mapper = mapper;
        }

        // GET: api/Service
        [HttpGet(ApiRoute.Service.GetAll)]
        public async Task<IActionResult> AllService()
        {
            IEnumerable<Services> AllArticle = await _serviceRepository.GetAllAsync();

            if (AllArticle.Any())
            {
                List<ServiceResponse> services = _mapper.Map<List<ServiceResponse>>(AllArticle);

                



                //List<ServiceResponse> services = AllArticle.Select(x =>
                //new ServiceResponse
                //{
                //    Id = x.Id,
                //    ArtisanId = x.ArtisanId,
                //    ServiceName = x.ServiceName,
                //    StatusId = x.StatusId,
                //    CreationDate = x.CreationDate,
                //    Descriptions = x.Descriptions
                //}
                //).ToList();

                return Ok(new { status = HttpStatusCode.OK, message = services });

            }
            return NoContent();
        }


        [HttpGet()]
        [Route(ApiRoute.Service.GetService)]
        public async Task<IActionResult> GetServices(int ArtisanId)
        {
            // ArtisanSubCategory thisSubCategory = await _artisanSubCatergoryRepository.GetByIdAsync(Cat);
            // bool isCatId = int.TryParse(CategoryId, out int catid);

            //if(isCatId)           
            //{
            //SubCategoryResponse subCategory = _mapper.Map<SubCategoryResponse>(thisSubCategory);

            List<ServiceResponse> subCategory = _mapper.Map<List<ServiceResponse>>(await dbContext.Services.Where(x => x.ArtisanId == ArtisanId).ToListAsync());



            if (subCategory.Any()) return Ok(new { status = HttpStatusCode.OK, message = subCategory });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });


            //}
            //return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid category id format" });            
        }

        // GET: api/Service/5
        [HttpGet(ApiRoute.Service.Get)]
        public async Task<IActionResult> ThisService(int id)
        {
           // string rawUrlString = HttpUtility.UrlDecode(id);
           //var decryptId = int.Parse(Decrypt(rawUrlString, _flutterRaveConf.EncryptionKey));
            Services getThisService = await _serviceRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (getThisService == null)
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "The requested service may have been discontinued by the Artisan" });

            ServiceResponse thisService = _mapper.Map<ServiceResponse>(getThisService);
            ServiceResponse response = _mapper.Map<ServiceResponse>(thisService);
            response.State = AppDictionary.States[getThisService.StateId ];
            response.Status = Enum.GetName(typeof(AppStatus), getThisService.StatusId);
            response.Category = AppDictionary.Category[getThisService.CategoryId ?? 0];
            response.SubCategory =  _subCatRepository.GetByAsync(x => x.Id.Equals(getThisService.SubCategoryId ?? 1)).FirstOrDefaultAsync().Result.SubCategories ;
            response.LGArea = _lgaRepository.GetByAsync(x => x.Id.Equals(getThisService.LgaId ?? 1)).FirstOrDefaultAsync().Result.Lga1;
           
            //ServiceResponse thisService = new ServiceResponse
            //{
            //    Id = getThisService.Id,
            //    ArtisanId = getThisService.ArtisanId,
            //    ServiceName = getThisService.ServiceName,
            //    StatusId = getThisService.StatusId,
            //    CreationDate = getThisService.CreationDate,
            //    Descriptions = getThisService.Descriptions
            //};

            return Ok(new { status = HttpStatusCode.OK, message = response });
        }

        // POST: api/Service
        [HttpPost(ApiRoute.Service.Create)]
        public async Task<IActionResult> Post([FromBody] ServiceRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });

            Artisan getArtisan = await _artisanRepository.GetByAsync(x => x.Id.Equals(model.ArtisanId)).FirstOrDefaultAsync();

            //int decryptId = int.Parse(Decrypt(model.ArtisanId, _flutterRaveConf.EncryptionKey));

            //if (model.UserId == 0) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user has been suspended, please contact the administrator" });

            UserLogin getUser = await _userLoginRepository.GetByAsync(x => x.Id.Equals(getArtisan.UserId)).FirstOrDefaultAsync();
            if (getUser == null)BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user does not exist on the platform" });

            int? userStatus = getUser?.StatusId;



            if (userStatus.Value != (int)AppStatus.Active) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This user has been suspended, please contact the administrator" });          

            Services newServie = _mapper.Map<Services>(model);           

            var newService = await _serviceRepository.CreateAsync(newServie);           

            ServiceResponse response = _mapper.Map<ServiceResponse>(newService);
            response.State = AppDictionary.States[model.StateId];
            response.Status = Enum.GetName(typeof(AppStatus), model.StatusId);
            response.Category = AppDictionary.Category[model.CategoryId];
            response.SubCategory =  _subCatRepository.GetByAsync(x => x.Id.Equals(model.SubCategoryId)).FirstOrDefaultAsync().Result.SubCategories;
            response.LGArea = _lgaRepository.GetByAsync(x => x.Id.Equals(model.LgaId)).FirstOrDefaultAsync().Result.Lga1;

            return CreatedAtAction("ThisService", new { id = newServie.Id }, new { status = HttpStatusCode.Created, message = response });
        }

        // PUT: api/Service/5
        [HttpPut(ApiRoute.Service.Update)]
        public async Task<IActionResult> Put( int id, [FromBody] ServiceRequest model)
        {
            //var decryptId = int.Parse(Decrypt(id, _flutterRaveConf.EncryptionKey));
            Services thisService = await _serviceRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (thisService == null)
            {
                return BadRequest();
            }
            
            thisService.Descriptions = model.Descriptions;
            thisService.ServiceName = model.ServiceName;
            thisService.StatusId = model.StatusId;

            thisService = await _serviceRepository.UpdateAsync(thisService);

            ServiceResponse response = _mapper.Map<ServiceResponse>(thisService);
            response.State = AppDictionary.States[model.StateId];
            response.Status = Enum.GetName(typeof(AppStatus), model.StatusId);
            response.Category = AppDictionary.Category[model.CategoryId];
            response.SubCategory = _subCatRepository.GetByAsync(x => x.Id.Equals(model.SubCategoryId)).FirstOrDefaultAsync().Result.SubCategories;
            response.LGArea = _lgaRepository.GetByAsync(x => x.Id.Equals(model.LgaId)).FirstOrDefaultAsync().Result.Lga1;

            // ServiceResponse serviceUpdateResponse = new ServiceResponse { Id = thisService.Id, ArtisanId = thisService.ArtisanId, Descriptions = thisService.Descriptions, ServiceName = thisService.ServiceName };
            return Ok(new { status = HttpStatusCode.BadRequest, message = response });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
