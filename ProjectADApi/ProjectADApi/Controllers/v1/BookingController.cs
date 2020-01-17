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
    public class BookingController : ControllerBase
    {
        readonly IRepository<Booking> _bookingRepository;

        public BookingController(IRepository<Booking> bookingRepository) => _bookingRepository = bookingRepository;



        // GET: api/Booking
        
        [HttpGet(ApiRoute.Order.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var allBooking = await _bookingRepository.GetAllAsync();

            if (allBooking != null)
                return Ok(allBooking);
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        //GET: api/Booking/5        
        [HttpGet(ApiRoute.Order.Get)]
        public async Task<IActionResult> GetById(int id)
        {
            Booking getBooking = await _bookingRepository.GetByIdAsync(id);

            if (getBooking != null)
                return Ok(getBooking);
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record found" });
        }

        // POST: api/Booking
        [HttpPost(ApiRoute.Order.Create)]
        public async Task<IActionResult> Post([FromBody] BookingRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Booking newJobRequesst = new Booking
            {
                ArtisanEmail = model.ArtisanEmail,
                ClientEmail = model.ClientEmail,
                Messages = model.Messages,
                MsgDate = DateTime.Now,
                MsgTime = DateTime.Now.TimeOfDay
            };

            var newBooking = await _bookingRepository.CreateAsync(newJobRequesst);
            return CreatedAtAction(nameof(GetById), new { id = newBooking.Id }, newBooking);
        }

        // PUT: api/Booking/5
        [HttpPut(ApiRoute.Order.Update)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete(ApiRoute.Order.Delete)]
        public void Delete(int id)
        {
        }
    }
}
