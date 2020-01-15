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
using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers
{
   // [Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArtisanController : ControllerBase
    {
        readonly IRepository<Artisan> _oniseOwoRepository;
        public ArtisanController(IRepository<Artisan> oniswOwoRepository) => _oniseOwoRepository = oniswOwoRepository;

        // GET: api/OniseOwo
       // [Route("[action]")]
        [HttpGet(ApiRoute.Artisan.GetAll)]
        public async Task<IActionResult> AwonOniseOwo()
        {
            IEnumerable<Artisan> awonOnibara = await _oniseOwoRepository.GetAllAsync();

            if (awonOnibara != null)
                return Ok(new { status = HttpStatusCode.OK, message = awonOnibara });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/OniseOwo/5
        //[Route("[action]/{id}")]
        [HttpGet(ApiRoute.Artisan.Get)]
        public async Task<IActionResult> OniseOwoyi(int id)
        {
            Artisan onibariyi = await _oniseOwoRepository.GetByIdAsync(id);
            if (onibariyi != null)
                return Ok(new { status = HttpStatusCode.OK, message = onibariyi });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record found" });
        }

        // POST: api/OniseOwo
        [HttpPost(ApiRoute.Artisan.Create)]
        public async Task<IActionResult> Post([FromBody] UserProfileRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artisan oniseOwoTuntun = new Artisan
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                IdcardNo = model.IdcardNo,
                PicturePath = model.PicturePath,
                Address = model.Address,
                State = model.State,
                ArtisanCategoryId = model.ArtisanCategoryId,
                AreaLocation = model.AreaLocation,
                EmailAddress = model.EmailAddress
                
            };
            Artisan kooniseOwoTuntun = await _oniseOwoRepository.CreateAsync(oniseOwoTuntun);
            return CreatedAtAction(nameof(OniseOwoyi), new { id = kooniseOwoTuntun.Id }, kooniseOwoTuntun);
        }

        // PUT: api/OniseOwo/5
        [HttpPut(ApiRoute.Artisan.Update)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete(ApiRoute.Artisan.Delete)]
        public void Delete(int id)
        {
        }
    }
}
