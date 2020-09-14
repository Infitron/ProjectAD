using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Contract.V1.Request;
using Microsoft.EntityFrameworkCore;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [Authorize]
    public class BankCodeController : ControllerBase
    {
        readonly IRepository<BankCodeLov> _bankCodeRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;
        public BankCodeController(IRepository<BankCodeLov> bankCodeRepository, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository)
        {

            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
           _bankCodeRepository = bankCodeRepository;
        }
        
        
        // GET: api/BankCode
        
        [HttpGet(ApiRoute.BankCode.GetAll)]
        public async Task<IActionResult> AllBankCode()
        {
            IEnumerable<BankCodeLov> AllArticle = await _bankCodeRepository.GetAllAsync();

            if (AllArticle.Any())
                return Ok(new { status = HttpStatusCode.OK, Message = AllArticle});
            return NoContent();
        }

        // GET: api/BankCode/5
        [HttpGet(ApiRoute.BankCode.Get)]
        public async Task<IActionResult> ThisBankCode(int id)
        {
            BankCodeLov thisBankCode = await _bankCodeRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (thisBankCode == null)
                return NotFound(new { status = HttpStatusCode.NotFound, Message = "The requested BankCode may have been discontinued by the Artisan" });

            return Ok(new { status = HttpStatusCode.OK, Message = thisBankCode });
        }

        // POST: api/BankCode
        [HttpPost(ApiRoute.BankCode.Create)]
        public async Task<IActionResult> Post([FromBody] BankodeRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            BankCodeLov newBankCode = new BankCodeLov
            {
                Bankcode = model.Bankcode,
                BankName = model.BankName,
                CreatedDate = DateTime.Now

            };
            await _bankCodeRepository.CreateAsync(newBankCode);

            return CreatedAtAction(nameof(ThisBankCode), new { id = newBankCode.Id }, new{status = HttpStatusCode.Created, message = newBankCode});
        }

        // PUT: api/BankCode/5
        [HttpPut(ApiRoute.BankCode.Update)]
        public async Task<IActionResult> Put(int id, [FromBody]BankodeRequest model)
        {
            BankCodeLov getBankCode = await _bankCodeRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if(getBankCode != null)
            {
                getBankCode.Bankcode = model.Bankcode;
                getBankCode.BankName = model.BankName;
                await _bankCodeRepository.UpdateAsync(getBankCode);

                return Ok(new { status = HttpStatusCode.OK, Message = getBankCode });
            }

            return NoContent();
        }

    //DELETE: api/ApiWithActions/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
}
