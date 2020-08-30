using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        private readonly projectadContext _dbContext;
        private readonly IMapper _mapper;

        public SearchController(IRepository<Artisan> artisanRepository, projectadContext dbContext, IMapper mapper, IRepository<ArtisanSubCategory> artisanSubCategoryRepository, IRepository<Services> servicesRepository)
        {
            _artisanRepository = artisanRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _artisanSubCategoryRepository = artisanSubCategoryRepository;
            _servicesRepository = servicesRepository;
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
            List<ServiceResponse> matchedServices = null;

            List<Services> Allservices = await _servicesRepository.GetByAsync(x => x.SubCategoryId.Equals(SubCatId)).ToListAsync();            

            if (Allservices.Any())
            {
                if (StateId.Value > 0 && LgId.Value == 0) Allservices = Allservices.FindAll(x => x.Id == StateId.Value);

                if (StateId.Value == 0 && LgId.Value > 0) Allservices = Allservices.FindAll(x => x.Id.Equals(LgId.Value));

                if (StateId.Value > 0 && LgId.Value > 0) Allservices = Allservices.FindAll(x => x.Id.Equals(LgId.Value));               

                // matchedServices = _mapper.Map<List<ServiceResponse>>(Allservices);
            }
            matchedServices = _mapper.Map<List<ServiceResponse>>(Allservices);
            return Ok(new { status = HttpStatusCode.NotFound, message = matchedServices ?? new List<ServiceResponse>() });
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
