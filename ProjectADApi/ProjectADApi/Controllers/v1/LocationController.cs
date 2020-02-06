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
using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {

        readonly IRepository<Location> _locationRepository;        

        public LocationController(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;            
        }

        // GET: api/Location
        //[HttpGet(ApiRoute.Location.GetAll)]
        //public async Task<IActionResult> AllLocation()
        //{
        //    IEnumerable<Location> AllArticle = await _locationRepository.GetAllAsync();

        //    if (AllArticle.Any())
        //        return Ok(AllArticle);
        //    return NoContent();
        //}

        // GET: api/Location/5
        [HttpGet(ApiRoute.Location.Get)]
        public async Task<IActionResult> ThisLocation(int id)
        {
            //Location thisLocation = await _locationRepository.GetByIdAsync(id);

            //if (thisLocation == null)
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "We could not find the location you requested" });

            //return Ok(new { status = HttpStatusCode.NotFound, Message = thisLocation });
        }

        // POST: api/Location
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] LocationRequest model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

        //    //Location newLocation = new Location
        //    //{
        //    //  State = model.State,
        //    //  Lga = model.Lga,
        //    //  Area = model.Area,
        //    //  Status = model.Status
        //    //};

        //    await _locationRepository.CreateAsync(newLocation);

        //    return CreatedAtAction(nameof(ThisLocation), new { id = newLocation.Id }, newLocation);

        //}

        // PUT: api/Location/5
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
