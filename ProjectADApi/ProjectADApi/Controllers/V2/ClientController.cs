using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Data;
using Api.Database.Model;
using EncryptionService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.Request;
using ProjectADApi.Controllers.V1.Contracts.Response;
using ProjectADApi.Controllers.V2.Contract;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        readonly IRepository<Client> _clientRepository;
        readonly IRepository<UserLogin> _userRepository;
        readonly bluechub_ProjectADContext _dbContext;

        public ClientController(IRepository<Client> onibaraRepository, IRepository<UserLogin> userRepository, bluechub_ProjectADContext dbContext)
        {
            _clientRepository = onibaraRepository;
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        // GET: api/Onibara
        //[Route("[action]")]
        [HttpGet(ApiRoute.Client.GetAll)]
        public async Task<IActionResult> AllClient()
        {
            // IEnumerable<Client> awonOnibara = await _clientRepository.GetAllAsync();
         var   clients = await _dbContext.Client.ToListAsync();

            if (clients != null)
            {
                List<ClientResponse> allClient = clients.Select(x =>
                new ClientResponse
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    PicturePath = x.PicturePath,
                    Address = x.Address,
                    State = x.State,
                    CreatedDate = x.CreatedDate
                }).ToList();

                return Ok(new { status = HttpStatusCode.OK, message = allClient });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        //GET: api/Onibara/5        
        [HttpGet(ApiRoute.Client.Get)]
        public async Task<IActionResult> ThisClient(int UserId)
        {
            Client onibariyi = await _clientRepository.GetByAsync(x => x.UserId.Equals(UserId)).FirstOrDefaultAsync();

            if (onibariyi != null)
            {
                ClientResponse thisClient = new ClientResponse
                {
                    Id = onibariyi.Id,
                    UserId = onibariyi.UserId,
                    FirstName = onibariyi.FirstName,
                    LastName = onibariyi.LastName,
                    PhoneNumber = onibariyi.PhoneNumber,
                    PicturePath = onibariyi.PicturePath,
                    Address = onibariyi.Address,
                    State = onibariyi.State,
                    CreatedDate = onibariyi.CreatedDate
                };
                return Ok(new { status = HttpStatusCode.OK, message = thisClient });
            }

            return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "No record found/Wrong user id supplied" });
        }

        //POST: api/Onibara
        [HttpPost(ApiRoute.Client.Create)]
        public async Task<IActionResult> Post([FromBody] ClientRequest model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            UserLogin thisUser = await _userRepository.GetByAsync(x => x.Id.Equals(model.UserId)).FirstOrDefaultAsync();

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
                CreatedDate = DateTime.Now,
                Code = AES.RandomPassword(),
                RefererCode = model.RefererCode
                
            };

            Client koOnibaraTuntun = await _clientRepository.CreateAsync(newClient);

            return CreatedAtAction(nameof(ThisClient), new { id = koOnibaraTuntun.Id }, new { status = HttpStatusCode.Created, message = koOnibaraTuntun });
        }

        // PUT: api/Onibara/5
        [HttpPut(ApiRoute.Client.Update)]
        public async Task<IActionResult>  Put(int id, [FromBody] ClientRequest model)
        {
            Client thisClient = await _clientRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (thisClient != null)
            {
                thisClient.FirstName = model.FirstName;
                thisClient.LastName = model.LastName;
                thisClient.PhoneNumber = model.PhoneNumber;
                thisClient.PicturePath = model.PicturePath;
                thisClient.Address = model.Address;
                thisClient.State = model.State;  
                thisClient.Code = thisClient.Code = thisClient.Code == null ? AES.RandomPassword() : thisClient.Code;
                thisClient.RefererCode = model.RefererCode;

                await _clientRepository.UpdateAsync(thisClient);

                return Ok(new { status = HttpStatusCode.OK, message = thisClient });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record  exist for the category specified" });
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete(ApiRoute.Client.Delete)]
        //public void Delete(int id)
        //{
        //}
    }
}
