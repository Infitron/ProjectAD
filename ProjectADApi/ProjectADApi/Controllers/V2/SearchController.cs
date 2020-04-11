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
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    public class SearchController : ControllerBase
    {
        readonly private IRepository<Artisan> _artisanRepository;
        private readonly projectadContext _dbContext;
        private readonly IMapper _mapper;

        public SearchController(IRepository<Artisan> artisanRepository, projectadContext dbContext, IMapper mapper) { _artisanRepository = artisanRepository; _dbContext =  dbContext ; _mapper = mapper; }

        // GET: api/Search
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Search/5
        [HttpGet(ApiRoute.Search.Get)]
        [Produces("application/json")]
        public async Task<IActionResult> DoSearch(int CatId, int LocationId)
        {
            //var AllArtisan = await _artisanRepository.GetAllAsync();

            var allArtisan = await Task.Run(() => _dbContext.Artisan.Where(x => x.ArtisanCategoryId == CatId && x.AreaLocationId == LocationId).ToList());

            if (allArtisan.Any())
            {
                List<ArtisanResponse> matchedArtisan = _mapper.Map<List<ArtisanResponse>>(allArtisan);
                return Ok(new { status = HttpStatusCode.OK, Message = matchedArtisan });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, message = new List<Artisan>() });
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
