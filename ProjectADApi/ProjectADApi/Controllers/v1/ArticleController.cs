using System;
using System.Collections.Generic;
using System.Linq;
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


        /// <summary>Gets all article submitted. This action would be performed by the admin </summary>
        /// 
        // GET: api/Article
        [HttpGet(ApiRoute.Article.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Article> AllArticle = await _articleRepository.GetAllAsync();
            if (AllArticle.Any())             
                return Ok(AllArticle);
            return NoContent();            
        }


        /// <summary>Gets an article submitted by the id </summary>
        /// 
        /// <remarks> 
        ///  
        /// </remarks>
        /// <param name="id"></param>
        /// 
        // GET: api/Article/5
        [HttpGet(ApiRoute.Article.Get)]
        public async Task<IActionResult> ThisArticle(int id)
        {
            Article thisArticle = await _articleRepository.GetAllAsync().ContinueWith((result) => {
                return result.Result.SingleOrDefault(x => x.Id == id);
            });
            if (thisArticle != null)
                return Ok(thisArticle);
            return NotFound(new { message = "No record found for this article"});
        }


        /// <summary>Create/Submit new Article </summary> 
        /// <remarks> 
        ///  Sample Request: 
        ///     POST api/v1/Article
        ///       {
        ///         "title": null,
        ///         "emailAddress": null,
        ///         "articleBody": null     
        ///       }
        ///  </remarks>
        /// 
        // POST: api/Article
        [HttpPost(ApiRoute.Article.Create)]
        public async Task<IActionResult> Post([FromBody] ArticleRequest model)
        {
            Article newArticle = new Article
            {
                Title = model.Title,
                EmailAddress = model.EmailAddress,
                ArticleBody = model.ArticleBody,
                DateApproved = DateTime.Now,
                CreatedDate = DateTime.Now,
                ApprovalStatusId = (int)ApprovalStatus.Pending                
            };

            await _articleRepository.CreateAsync(newArticle);
           
           return CreatedAtAction(nameof(ThisArticle), new { id = newArticle.Id }, newArticle);          

        }


        /// <summary>Updates an article </summary>
        /// 
        /// <remarks> 
        ///  
        /// </remarks>
        /// <param name="model"></param>
        /// 
        // PUT: api/Article/5
        [HttpPut(ApiRoute.Article.Update)]
        public async Task<IActionResult> Put([FromBody]Article model)
        {
            Article thisArticle = await _articleRepository.GetByIdAsync(model.Id);
            if (thisArticle == null)
                return NotFound(new { message = "This article was not found"});

            thisArticle.ApprovalStatusId = model.ApprovalStatusId;

            await _articleRepository.UpdateAsync(thisArticle);
            return Ok(new { message = "Ate has been updated" });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
