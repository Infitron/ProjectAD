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
    public class BankDetailsController : ControllerBase
    {
        readonly IRepository<ArtisanBankDetails> _artisanBankDetialsRepository;

        public BankDetailsController(IRepository<ArtisanBankDetails> artisanBankDetialsRepository)
        {
            _artisanBankDetialsRepository = artisanBankDetialsRepository;
        }

        // GET: api/BankDetails
        [HttpGet(ApiRoute.BankDetail.GetAll)]
        public async Task<IActionResult> AllBankDetail()
        {
            IEnumerable<ArtisanBankDetails> AllArticle = await _artisanBankDetialsRepository.GetAllAsync();
            if (AllArticle.Any())
                return Ok(AllArticle);
            return NoContent();
        }

        // GET: api/BankDetails/5
        [HttpGet(ApiRoute.BankDetail.Get)]
        public async Task<IActionResult> ThisBankDetail(int id)
        {
            ArtisanBankDetails thisBankDetail = await _artisanBankDetialsRepository.GetByIdAsync(id);
            if (thisBankDetail != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisBankDetail });
            return NotFound(new { status = HttpStatusCode.NotFound, message = "No record found for this article" });
        }

        // POST: api/BankDetails
        [HttpPost(ApiRoute.BankDetail.Create)]
        public async Task<IActionResult> Post([FromBody] BankDetaildRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            ArtisanBankDetails newProject = new ArtisanBankDetails
            {
                EmailAddress = model.EmailAddress,
                AccountName = model.AccountName,
                AccountNumber = model.AccountNumber,
                BankName = model.BankName,
                Bvn = model.Bvn,
                CreatedDate = DateTime.Now
            };

            await _artisanBankDetialsRepository.CreateAsync(newProject);

            return CreatedAtAction(nameof(ThisBankDetail), new { id = newProject.Id }, newProject);
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
