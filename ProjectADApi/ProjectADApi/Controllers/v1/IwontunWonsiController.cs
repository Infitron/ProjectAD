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
using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1;

namespace ProjectADApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IwontunWonsiController : ControllerBase
    {
        readonly IRepository<Rating> _ratingRepository;
        readonly IRepository<Artisan> _artisanRepository;

        public IwontunWonsiController(IRepository<Rating> ratingRepository, IRepository<Artisan> artisanRepository)
        {
            _ratingRepository = ratingRepository;
            _artisanRepository = artisanRepository;
        }

        //// GET: api/Rating
        //[Route("[action]")]
        //[HttpGet]
        //public IEnumerable<string> IwontunWonsi()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Rating/5
        //[Route("[action]/{id}")]        
        [HttpGet(ApiRoute.Rating.Get)]
        public async Task<IActionResult> IwontunWonsimi(int id)
        {
            Artisan waOniseOwo = await _artisanRepository.GetAllAsync().ContinueWith( (result) =>
            {
                 return  result.Result.SingleOrDefault(x => x.Id.Equals(id));
            });

            if(waOniseOwo == null)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "We could not fine this user" });
            }

            List<Rating> myratin = await _ratingRepository.GetAllAsync().ContinueWith( (result) => 
            {
                return result.Result.Where(x => x.ArtisanEmail.Equals(waOniseOwo.EmailAddress)).ToList();
            });

            if (myratin.Any())
            {
                return Ok(new { status = HttpStatusCode.OK, message = myratin});
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No rating/Comment fount for this artisan" });
        }

        // POST: api/Rating
        [HttpPost(ApiRoute.Rating.Create)]
        public async Task<IActionResult> Post([FromBody] RatingRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rating IwontunWonsiTuntun = new Rating
            {
                ArtisanEmail = model.ArtisanEmail,
                ClientEmail = model.ClientEmail,
                Description = model.Description,
                Remarks = model.Comment,
                Rating1 = model.Rating1,
                JobEndDate = model.JobEndDate,
                JobStartDate = model.JobStartDate

            };

            Rating iwontunWonsiTutun = await _ratingRepository.CreateAsync(IwontunWonsiTuntun);
            return CreatedAtAction(nameof(IwontunWonsimi), new { id = iwontunWonsiTutun.Id }, iwontunWonsiTutun);
        }

        // PUT: api/Rating/5
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
