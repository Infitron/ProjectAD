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

namespace ProjectADApi.Controllers.V1
{
   //[ApiVersion("1")]
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BankDetailsController : ControllerBase
    {
        readonly IRepository<BankDetails> _artisanBankDetialsRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;

        public BankDetailsController(IRepository<BankDetails> artisanBankDetialsRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository)
        {
            _artisanBankDetialsRepository = artisanBankDetialsRepository;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;

        }

        // GET: api/BankDetails
        [HttpGet(ApiRoute.BankDetail.GetAll)]
        public async Task<IActionResult> AllBankDetail()
        {
            IEnumerable<BankDetails> AllBankDetails = await _artisanBankDetialsRepository.GetAllAsync();
            if (AllBankDetails.Any())
                return Ok(new { status = HttpStatusCode.OK, message = AllBankDetails });
            return NoContent();
        }

        // GET: api/BankDetails/5
        [HttpGet(ApiRoute.BankDetail.Get)]
        public async Task<IActionResult> ThisBankDetail(int id)
        {
            BankDetails thisBankDetail = await _artisanBankDetialsRepository.GetByIdAsync(id);
            if (thisBankDetail != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisBankDetail });
            return BadRequest(new { status = HttpStatusCode.BadRequest, message = "No record found for this article" });
        }

        // POST: api/BankDetails
        [HttpPost(ApiRoute.BankDetail.Create)]
        public async Task<IActionResult> Post([FromBody] BankDetaildRequest model)
        {
            UserLogin thisUser = await _userLoginRepository.GetByIdAsync(model.UserId);
            Artisan thisArtisan = null;

            BankDetails thisBankDetail = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });
            }

            thisBankDetail = await _artisanBankDetialsRepository.GetAllAsync().ContinueWith((resultset) =>
            {
                return resultset.Result.SingleOrDefault(x => x.Bvn.Equals(model.Bvn));
            });

            if (thisBankDetail != null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Duplicate BVN" });
            }

            thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((resultset) =>
            {
                return resultset.Result.SingleOrDefault(x => x.UserId.Equals(thisUser.Id));
            });



            if (thisUser != null)
            {
                if (thisArtisan == null)
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "User do not have an Artisan Profile" });
                }

                BankDetails newProject = new BankDetails
                {
                    ArtisanId = thisArtisan.Id,
                    AccountNumber = model.AccountNumber,
                    AccountName = model.AccountName,
                    BankCode = model.BankCode,
                    Bvn = model.Bvn,
                    CreatedDate = DateTime.Now
                };

                await _artisanBankDetialsRepository.CreateAsync(newProject);

                return CreatedAtAction(nameof(ThisBankDetail), new { id = newProject.Id }, new { status = HttpStatusCode.Created, message = newProject });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "We could not the determine who this user is" });

        }

        // PUT: api/BankDetails/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
