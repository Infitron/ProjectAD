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
    public class OnibaraController : ControllerBase
    {
        readonly IRepository<Client> _onibaraRepository;

        public OnibaraController(IRepository<Client> onibaraRepository) => _onibaraRepository = onibaraRepository;

        // GET: api/Onibara
        //[Route("[action]")]
        [HttpGet(ApiRoute.Client.GetAll)]
        public async Task<IActionResult> GbogboOnibara()
        {
            IEnumerable<Client> awonOnibara = await _onibaraRepository.GetAllAsync();

            if (awonOnibara != null)
                return Ok(new { status = HttpStatusCode.OK, message = awonOnibara });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/Onibara/5
        //[Route("[action]/{id}")]
        [HttpGet(ApiRoute.Client.Get)]
        public async Task<IActionResult> Onibarayi(int id)
        {
            Client onibariyi = await _onibaraRepository.GetByIdAsync(id);
            if (onibariyi != null)
                return Ok(new { status = HttpStatusCode.OK, message = onibariyi });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record found" });
        }

        // POST: api/Onibara
        [HttpPost(ApiRoute.Client.Create)]
        public async Task<IActionResult> Post([FromBody] ClientRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client onibaraTuntun = new Client { FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                IdcardNo = model.IdcardNo,
                PicturePath = model.PicturePath,
                Address = model.Address,
                State = model.State
            };

            Client koOnibaraTuntun = await _onibaraRepository.CreateAsync(onibaraTuntun);
            
            return CreatedAtAction(nameof(Onibarayi), new { id = koOnibaraTuntun.Id }, koOnibaraTuntun);
        }

        // PUT: api/Onibara/5
        [HttpPut(ApiRoute.Client.Update)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete(ApiRoute.Client.Delete)]
        public void Delete(int id)
        {
        }
    }
}
