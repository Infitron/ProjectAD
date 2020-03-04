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
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArticleController : ControllerBase
    {
        readonly private IRepository<Article> _articleRepository;

        public ArticleController(IRepository<Article> articleRepository) => _articleRepository = articleRepository;



        // GET: api/Article
        [HttpGet(ApiRoute.Article.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Article> AllArticle = await _articleRepository.GetAllAsync().ContinueWith((result) => {
                return result.Result.Where(x => x.ApprovalStatusId.Equals((int)AppStatus.Approved));
            });

            if (AllArticle.Any())
                return Ok(new { status = HttpStatusCode.OK, message = AllArticle });
            return NoContent();
        }

        // GET: api/Article/5
        [HttpGet(ApiRoute.Article.Get)]
        public async Task<IActionResult> ThisArticle(int id)
        {
            Article thisArticle = await _articleRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.Id == id);
            });

            if (thisArticle != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisArticle });
            return BadRequest(new { status = HttpStatusCode.BadRequest, message = "No record found for this article" });
        }

        // POST: api/Article
        [HttpPost(ApiRoute.Article.Create)]
        public async Task<IActionResult> Post([FromBody] ArticleRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Article newArticle = new Article
            {
                Title = model.Title,
                UserId = model.UserId,
                ArticleBody = model.ArticleBody,
                DateApproved = DateTime.Now,
                CreatedDate = DateTime.Now,
                ApprovalStatusId = (int)AppStatus.Submitted
            };

            await _articleRepository.CreateAsync(newArticle);

            return CreatedAtAction(nameof(ThisArticle), new { id = newArticle.Id }, newArticle);

        }

        // PUT: api/Article/5
        [HttpPut(ApiRoute.Article.Update)]
        public async Task<IActionResult> Put(int id, [FromBody]Article model)
        {
            Article thisArticle = await _articleRepository.GetByIdAsync(model.Id);
            if (thisArticle == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "This article was not found" });

            thisArticle.ArticleBody = model.ArticleBody;
            thisArticle.ApprovalStatusId = model.ApprovalStatusId;

            await _articleRepository.UpdateAsync(thisArticle);
            return Ok(new { status = HttpStatusCode.OK, message = "Ate has been updated" });
        }

    }
}
