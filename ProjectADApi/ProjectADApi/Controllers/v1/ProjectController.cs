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
    public class ProjectController : ControllerBase
    {
        readonly IRepository<Projects> _projectRepository;

        public ProjectController(IRepository<Projects> ProjectRepository)
        {
            _projectRepository = ProjectRepository;
        }

        //GET: api/Project
        [HttpGet(ApiRoute.Project.GetAll)]
        public async Task<IActionResult> AllProject()
        {
            IEnumerable<Projects> AllArticle = await _projectRepository.GetAllAsync();
            if (AllArticle.Any())
                return Ok(new { status = HttpStatusCode.OK, message = AllArticle });
            return NotFound(new { status = HttpStatusCode.NotFound, message = "No record found" });
        }

        // GET: api/Project/5
        [HttpGet(ApiRoute.Project.Get)]
        public async Task<IActionResult> ThisProject(int id)
        {
            Projects thisProject = await _projectRepository.GetByIdAsync(id);
            if (thisProject != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisProject });
            return BadRequest(new { status = HttpStatusCode.BadRequest, message = "No record found for this article" });
        }

        // POST: api/Project
        [HttpPost(ApiRoute.Project.Create)]
        public async Task<IActionResult> Post([FromBody] ProjectRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Projects newProject = new Projects
            {
                ArtisanId = model.ArtisanId,
                ClientId = model.ClientId,
                QuoteId = model.QuoteId,
                ProjectName = model.ProjectName,
                StatusId = (int)AppStatus.Initiated,
                CreationDate = DateTime.Now,
                StartDate = model.StartDate
            };

            await _projectRepository.CreateAsync(newProject);

            return CreatedAtAction(nameof(ThisProject), new { id = newProject.Id }, new { status = HttpStatusCode.Created, message = newProject });
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectUpdateRequest model)
        {
            Projects getProject = await _projectRepository.GetByIdAsync(id);

            if (getProject == null)
                return NotFound(new { status = HttpStatusCode.NotFound, meesage = "We project your requesting does not exist" });
            
            getProject.StatusId = model.StatusId;
            getProject.EndDate = model.EndDate;
            getProject.QuoteId = model.QuoteId;

            await _projectRepository.UpdateAsync(getProject);

            return Ok(new { status = HttpStatusCode.OK, message = getProject });        
            
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
