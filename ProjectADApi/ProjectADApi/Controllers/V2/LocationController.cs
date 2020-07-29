using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.ApiConfig;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {

        readonly IRepository<Location> _locationRepository;
        readonly IMapper _mapper;


        public LocationController(IRepository<Location> locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        // GET: api/Location
        [HttpGet(ApiRoute.Location.GetAll)]
        public async Task<IActionResult> AllLocation()
        {
            IEnumerable<Location> Locations = await _locationRepository.GetAllAsync();

            if (Locations.Any())
            {
                List<LocationResponse> locationReponse = _mapper.Map<List<LocationResponse>>(Locations);              
                return Ok(new { status = HttpStatusCode.OK, Message = locationReponse });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/Location/5
        [HttpGet(ApiRoute.Location.Get)]
        public async Task<IActionResult> ThisLocation(int id)
        {
            Location thisLocation = await _locationRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            LocationResponse locationsResponse = _mapper.Map<LocationResponse>(thisLocation);           

            if (thisLocation == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "We could not find the location you requested" });

            return Ok(new { status = HttpStatusCode.NotFound, Message = locationsResponse });
        }

        // POST: api/Location
        [HttpPost(ApiRoute.Location.Create)]
        public async Task<IActionResult> Post([FromBody] LocationRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Location newLocation = _mapper.Map<Location>(model);          

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
