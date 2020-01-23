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
    public class ArtisanCategoryController : ControllerBase
    {
        readonly private IRepository<ArtisanCategories> _artisanCatergoryRepository;

        public ArtisanCategoryController(IRepository<ArtisanCategories> artisanCatergoryRepository) => _artisanCatergoryRepository = artisanCatergoryRepository;

        // GET: api/ArtisanCategory 
        [HttpGet(ApiRoute.ACategory.GetAll)]
        public async Task<IActionResult> AllCategory()
        {
            IEnumerable<ArtisanCategories> allCategory = await _artisanCatergoryRepository.GetAllAsync();

            if (allCategory != null)
                return Ok(new { status = HttpStatusCode.OK, message = allCategory });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/ArtisanCategory/5
        [HttpGet(ApiRoute.ACategory.Get)]
        public async Task<IActionResult> GetThisCategory(int id)
        {
            ArtisanCategories thisCategory = await _artisanCatergoryRepository.GetByIdAsync(id);
            if (thisCategory != null)
                return Ok(new { status = HttpStatusCode.OK, message = thisCategory });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record found" });
        }

        // POST: api/ArtisanCategory
        [HttpPost(ApiRoute.ACategory.Create)]
        public async Task<IActionResult> Post([FromBody] ArCatergoryRequest model)
        {
            ArtisanCategories addNew = new ArtisanCategories
            {
                CategoryDescr = model.CategoryDescr,
                CategoryName = model.CategoryName,
                SubCategories = model.SubCategories
            };

            var isAdded = await _artisanCatergoryRepository.CreateAsync(addNew);

            return CreatedAtAction(nameof(GetThisCategory), new { id = isAdded.Id }, isAdded);
        }

        // PUT: api/ArtisanCategory/5
        [HttpPut(ApiRoute.ACategory.Update)]
        public async Task<IActionResult> Put([FromBody] ArCatergoryRequest model)
        {
            ArtisanCategories thisCategory = await _artisanCatergoryRepository.GetByIdAsync(model.Id);
            if (thisCategory != null)
            {
                thisCategory.CategoryDescr = model.CategoryDescr;
                thisCategory.CategoryName = model.CategoryName;

                await _artisanCatergoryRepository.UpdateAsync(thisCategory);
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record  exist for the category specified" });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
