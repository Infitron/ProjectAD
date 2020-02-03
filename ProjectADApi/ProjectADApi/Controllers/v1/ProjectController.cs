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
    public class ProjectController : ControllerBase
    {
        readonly IRepository<Projects> _projectRepository;

        public ProjectController(IRepository<Projects> ProjectRepository)
        {
            _projectRepository = ProjectRepository;
        }

        // GET: api/Project
        [HttpGet(ApiRoute.Project.GetAll)]
        public async Task<IActionResult> AllProject()
        {
            IEnumerable<Projects> AllArticle = await _projectRepository.GetAllAsync();
            if (AllArticle.Any())
                return Ok(AllArticle);
            return NoContent();
        }

        // GET: api/Project/5
        [HttpGet(ApiRoute.Project.Get)]
        public async Task<IActionResult> ThisProject(int id)
        {
            Projects thisProject = await _projectRepository.GetByIdAsync(id);
            if (thisProject != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisProject });
            return NotFound(new { status = HttpStatusCode.NotFound, message = "No record found for this article" });
        }

        // POST: api/Project
        [HttpPost(ApiRoute.Project.Create)]
        public async Task<IActionResult> Post([FromBody] ProjectRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });

            Projects newProject = new Projects
            {
                ArtisanEmail = model.ArtisanEmail,
                ClientEmail = model.ClientEmail,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                ProjectStatus = "Pending",
                ProjectName = model.ProjectName,
                BookingId = model.BookingId,
                CreationDate = DateTime.Now
            };

            await _projectRepository.CreateAsync(newProject);

            return CreatedAtAction(nameof(ThisProject), new { id = newProject.Id }, newProject);
        }

        // PUT: api/Project/5
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
