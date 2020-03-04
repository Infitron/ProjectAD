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
using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1;

namespace ProjectADApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        readonly IRepository<Client> _clientRepository;
        readonly IRepository<UserLogin> _userRepository;

        public ClientController(IRepository<Client> onibaraRepository, IRepository<UserLogin> userRepository)
        {
            _clientRepository = onibaraRepository;
            _userRepository = userRepository;
        }

        // GET: api/Onibara
        //[Route("[action]")]
        [HttpGet(ApiRoute.Client.GetAll)]
        public async Task<IActionResult> AllClient()
        {
            IEnumerable<Client> awonOnibara = await _clientRepository.GetAllAsync();

            if (awonOnibara != null)
                return Ok(new { status = HttpStatusCode.OK, message = awonOnibara });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        //GET: api/Onibara/5        
        [HttpGet(ApiRoute.Client.Get)]
        public async Task<IActionResult> ThisClient(int id)
        {
            Client onibariyi = await _clientRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.Id == id);
            });
            if (onibariyi != null)
                return Ok(new { status = HttpStatusCode.OK, message = onibariyi });
            return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "No record found/Wrong user id supplied" });
        }

        //POST: api/Onibara
        [HttpPost(ApiRoute.Client.Create)]
        public async Task<IActionResult> Post([FromBody] ClientRequest model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            UserLogin thisUser = await _userRepository.GetByIdAsync(model.UserId);

            if (thisUser == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This could determine the user credential, you profile creation stopped" });


            if (thisUser.StatusId != (int)AppStatus.Active)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "This Client is not longer active on this platform" });


            Client newClient = new Client
            {
                FirstName = model.FirstName,
                UserId = model.UserId,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                PicturePath = model.PicturePath,
                Address = model.Address,
                State = model.State,
                CreatedDate = DateTime.Now
            };

            Client koOnibaraTuntun = await _clientRepository.CreateAsync(newClient);

            return CreatedAtAction(nameof(ThisClient), new { id = koOnibaraTuntun.Id }, koOnibaraTuntun);
        }

        // PUT: api/Onibara/5
        //[HttpPut(ApiRoute.Client.Update)]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete(ApiRoute.Client.Delete)]
        //public void Delete(int id)
        //{
        //}
    }
}
