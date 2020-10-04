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
using ProjectADApi.Contract.V1;

namespace ProjectADApi.Controllers.V1
{
   [ApiVersion("1", Deprecated =true)]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpGet(ApiRoute.Search.Get)]
        [Produces("application/json")]
        public async Task<IActionResult> DoSearch(int CatId, int LocationId)
        {
            var AllArtisan = await _artisanRepository.GetAllAsync();

            var matchedArtisan = AllArtisan.Where(x => x.ArtisanCategoryId ==CatId && x.AreaLocationId==LocationId).ToList(); 

            if (matchedArtisan.Any())
            {
                return Ok(new { status = HttpStatusCode.OK, Message = matchedArtisan});
            }
            return NotFound(new { status = HttpStatusCode.NotFound, message = new List<Artisan>() });
        }

        // POST: api/Search
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        
        // PUT: api/Search/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
