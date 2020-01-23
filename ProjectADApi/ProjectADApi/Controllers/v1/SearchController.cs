using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectADApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        readonly private IRepository<Artisan> _artisanRepository;

        public SearchController(IRepository<Artisan> artisanRepository) => _artisanRepository = artisanRepository;

        // GET: api/Search
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Search/5
        [HttpGet("{CatId}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int CatId)
        {
            IEnumerable<Artisan> foundArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanCategoryId.Equals(CatId));
            });

            if (foundArtisan.Any())
            {
                return Ok(foundArtisan);
            }
            return NotFound(new List<Artisan>());
        }

        // POST: api/Search
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        // PUT: api/Search/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
