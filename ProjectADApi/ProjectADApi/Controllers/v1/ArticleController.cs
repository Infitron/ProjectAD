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
using ProjectADApi.Contract.V1.Response;

namespace ProjectADApi.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArticleController : ControllerBase
    {
        private readonly IRepository<Article> _articleRepository;        

        public ArticleController(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
            
        }

        // GET: api/Article
        [HttpGet(ApiRoute.Article.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            projectadContext dbcontxt = new projectadContext();

            List<ArticleResponse> AllArticle = await _articleRepository.GetAllAsync().ContinueWith((resultset) =>
            {
                return resultset.Result.Select(x =>
                new ArticleResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    UserName = x.User.UserName,
                    ArticleBody = x.ArticleBody,
                    ApprovalStatus = x.ApprovalStatus.Status,
                    CreatedDate = x.CreatedDate,
                    DateApproved = x.DateApproved
                }).ToList();
            });

            if (AllArticle.Any())
                return Ok(new { status = HttpStatusCode.OK, message = AllArticle });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/Article/5
        [HttpGet(ApiRoute.Article.Get)]
        public async Task<IActionResult> ThisArticle(int id)
        {
            Article thisArticle = await _articleRepository.GetByIdAsync(id);

            ArticleResponse articleRepsonse = null;

            if (thisArticle != null)
            {
                articleRepsonse = new ArticleResponse
                {
                    Id = thisArticle.Id,
                    Title = thisArticle.Title,
                    UserName = thisArticle.User.UserName,
                    ArticleBody = thisArticle.ArticleBody,
                    ApprovalStatus = thisArticle.ApprovalStatus.Status,
                    CreatedDate = thisArticle.CreatedDate,
                    DateApproved = thisArticle.DateApproved
                };
            }

            if (thisArticle != null)
                return Ok(new { status = HttpStatusCode.OK, message = articleRepsonse });
            return BadRequest(new { status = HttpStatusCode.BadRequest, message = "No record found for this article" });
        }

        // POST: api/Article
        [HttpPost(ApiRoute.Article.Create)]
        public async Task<IActionResult> Post([FromBody] ArticleRequest model)
        {
            if (!ModelState.IsValid) return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

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

            return CreatedAtAction(nameof(ThisArticle), new { id = newArticle.Id }, new { status = HttpStatusCode.Created, message = newArticle });
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
