using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Data;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProjectADApi.ApiConfig;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    public class SearchController : ControllerBase
    {
        readonly private IRepository<Artisan> _artisanRepository;
        readonly private IRepository<ArtisanSubCategory> _artisanSubCategoryRepository;
        readonly private IRepository<Services> _servicesRepository;
        private readonly bluechub_ProjectADContext _dbContext;
        private readonly IMapper _mapper;
        readonly IRepository<ArtisanSubCategory> _subCatRepository;
        readonly IRepository<Lga> _lgaRepository;

        public SearchController(IRepository<Artisan> artisanRepository, bluechub_ProjectADContext dbContext, IMapper mapper, IRepository<ArtisanSubCategory> artisanSubCategoryRepository, IRepository<Services> servicesRepository, IRepository<ArtisanSubCategory> subCatRepository, IRepository<Lga> lgaRepository)
        {
            _artisanRepository = artisanRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _artisanSubCategoryRepository = artisanSubCategoryRepository;
            _servicesRepository = servicesRepository;
            _subCatRepository = subCatRepository;
            _lgaRepository = lgaRepository;
        }

        // GET: api/Search
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Search/5
        [HttpGet(ApiRoute.Search.Get)]
        [Produces("application/json")]
        public async Task<IActionResult> DoSearch(int SubCatId, int? StateId = 0, int? LgId = 0)
        {
            //var AllArtisan = await _artisanRepository.GetAllAsync();
            List<ServiceResponse> matchedServices = new List<ServiceResponse>();

            List<Services> Allservices = await _servicesRepository.GetByAsync(x => x.SubCategoryId.Equals(SubCatId)).ToListAsync();            

            if (Allservices.Any())
            {
                if (StateId.Value > 0 && LgId.Value == 0) Allservices = Allservices.Where(x => x.StateId == StateId.Value).ToList();

                if (StateId.Value == 0 && LgId.Value > 0) Allservices = Allservices.Where(x => x.LgaId.Equals(LgId.Value)).ToList();

                if (StateId.Value > 0 && LgId.Value > 0) Allservices = Allservices.Where(x => x.StateId.Equals(StateId.Value) && x.LgaId.Equals(LgId.Value)).ToList();               

                // matchedServices = _mapper.Map<List<ServiceResponse>>(Allservices);
            }

            for(int i = 0; i < Allservices.Count; i++)
            {
                var service = _mapper.Map<ServiceResponse>(Allservices[i]);
                service.State = AppDictionary.States[Allservices[i].StateId];
                service.Status = Enum.GetName(typeof(AppStatus), Allservices[i].StatusId);
                service.Category = AppDictionary.Category[Allservices[i].CategoryId ?? 0];
                service.SubCategory = _subCatRepository.GetByAsync(x => x.Id.Equals(Allservices[i].SubCategoryId ?? 1)).FirstOrDefaultAsync().Result.SubCategories;
                service.LGArea = _lgaRepository.GetByAsync(x => x.Id.Equals(Allservices[i].LgaId ?? 1)).FirstOrDefaultAsync().Result.Lga1;
            //}
            //foreach (var thisService in Allservices) {
                
            //    var service = _mapper.Map<ServiceResponse>(thisService);
            //    service.State = AppDictionary.States[thisService.StateId ?? 0];
            //    service.Status = Enum.GetName(typeof(AppStatus), thisService.StatusId);
            //    service.Category = AppDictionary.Category[thisService.CategoryId ?? 0];
            //    service.SubCategory = _subCatRepository.GetByAsync(x => x.Id.Equals(thisService.SubCategoryId ?? 1)).FirstOrDefaultAsync().Result.SubCategories;
            //    service.LGArea = _lgaRepository.GetByAsync(x => x.Id.Equals(thisService.LgaId ?? 1)).FirstOrDefaultAsync().Result.Lga1;

                matchedServices.Add(service);
            }
           
            return Ok(new { status = HttpStatusCode.OK, message = matchedServices ?? new List<ServiceResponse>() });
        }
        //// GET: api/Search/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Search
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Search/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
