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
using Microsoft.EntityFrameworkCore;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers.V1
{
   [ApiVersion("1", Deprecated =true)]   
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuoteController : ControllerBase
    {
        readonly private IRepository<Quote> _quoteRepository;
        readonly private IRepository<Projects> _projectRepository;

        public QuoteController(IRepository<Quote> quoteRepository, IRepository<Projects> projectRepository)
        {
            _quoteRepository = quoteRepository;
            _projectRepository = projectRepository;
        }


        /// <summary>Gets all Qoutes submitted for various projects </summary>
        /// 
        // GET: api/Article
        // GET: api/Quote
        //[HttpGet(ApiRoute.Quote.GetAll)]
        //public async Task<IActionResult> Get()
        //{
        //    IEnumerable<Quote> AllArticle = await _quoteRepository.GetAllAsync();
        //    if (AllArticle.Any())
        //        return Ok(AllArticle);
        //    return NoContent();
        //}

        // GET: api/Quote/5
        [HttpGet(ApiRoute.Quote.Get)]
        public async Task<IActionResult> ThisQuote(int projectId)
        {
            Quote thisArticle = await _quoteRepository.GetByAsync(x => x.Id.Equals(projectId)).FirstOrDefaultAsync();
            if (thisArticle != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisArticle });
            return NotFound(new { status = HttpStatusCode.NotFound, message = "No record found for this article" });
        }

        // POST: api/Quote
        [HttpPost(ApiRoute.Quote.Create)]
        public async Task<IActionResult> Post([FromBody] QuoteRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Quote newQuote = new Quote
            {
                Price = model.Price,
                Quantity = model.Quantity,
                Descr = model.Descr,
                Address1 = model.Address1,
                Item = model.Item,
                Discount = model.Discount,
                Vat = model.Vat,
                ArtisanId = model.ArtisanId
            };

            await _quoteRepository.CreateAsync(newQuote);

            return CreatedAtAction(nameof(ThisQuote), new { id = newQuote.Id }, new { status = HttpStatusCode.Created, message = newQuote });
        }

        //// PUT: api/Quote/5
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
