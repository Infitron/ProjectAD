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
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;

namespace ProjectADApi.Controllers.V1
{
   //[ApiVersion("1")]
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
        [HttpGet(ApiRoute.Location.GetAll)]
        public async Task<IActionResult> AllLocation()
        {
            IEnumerable<Location> AllArticle = await _locationRepository.GetAllAsync();

            if (AllArticle.Any())
            {
                List<LocationResponse> allLocation = AllArticle.Select(x => new LocationResponse
                {
                    Id = x.Id,
                    Area = x.Area,
                    Lga = x.Lga,
                    State = x.State,
                    Status = x.Status.Status,
                    CreatedDate = x.CreatedDate
                }).ToList();
                return Ok(new { status = HttpStatusCode.OK, Message = allLocation });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/Location/5
        [HttpGet(ApiRoute.Location.Get)]
        public async Task<IActionResult> ThisLocation(int id)
        {
            Location thisLocation = await _locationRepository.GetByIdAsync(id);

            LocationResponse locationsResponse = new LocationResponse
            {
                Area = thisLocation?.Area,
                Id = thisLocation.Id,
                Lga = thisLocation?.Lga,
                State = thisLocation?.State,
                Status = thisLocation?.Status?.Status
            };

            if (thisLocation == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "We could not find the location you requested" });

            return Ok(new { status = HttpStatusCode.NotFound, Message = locationsResponse });
        }

        // POST: api/Location
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Location newLocation = new Location
            {
                State = model.State,
                Lga = model.Lga,
                Area = model.Area,
                StatusId = (int)AppStatus.Active
            };

            await _locationRepository.CreateAsync(newLocation);

            return CreatedAtAction(nameof(ThisLocation), new { id = newLocation.Id }, new { status = HttpStatusCode.Created, message = newLocation });
        }

        //PUT: api/Location/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        //// DELETE: api/ApiWithActions/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
