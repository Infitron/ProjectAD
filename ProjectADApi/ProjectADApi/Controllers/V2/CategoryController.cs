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
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        readonly private IRepository<ArtisanCategories> _artisanCatergoryRepository;

        public CategoryController(IRepository<ArtisanCategories> artisanCatergoryRepository) => _artisanCatergoryRepository = artisanCatergoryRepository;

        // GET: api/ArtisanCategory 
        [HttpGet(ApiRoute.Category.GetAll)]
        public async Task<IActionResult> AllCategory()
        {
            IEnumerable<ArtisanCategories> allCategory = await _artisanCatergoryRepository.GetAllAsync();

            if (allCategory != null)
            {
                List<CategoryResponse> allACategoryResponse = allCategory.Select(x => new CategoryResponse
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate
                }).ToList();

                return Ok(new { status = HttpStatusCode.OK, message = allACategoryResponse });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/ArtisanCategory/5
        [HttpGet(ApiRoute.Category.Get)]
        public async Task<IActionResult> GetThisCategory(int id)
        {
            ArtisanCategories thisCategory = await _artisanCatergoryRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            CategoryResponse _thisCategory = new CategoryResponse
            {
                Id = thisCategory.Id,
                CategoryName = thisCategory.CategoryName,
                Description = thisCategory.Description,
                CreatedDate = thisCategory.CreatedDate
            };

            if (thisCategory != null)
                return Ok(new { status = HttpStatusCode.OK, message = _thisCategory });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record found" });
        }

        // POST: api/ArtisanCategory
        [HttpPost(ApiRoute.Category.Create)]
        public async Task<IActionResult> Post([FromBody] CatergoryRequest model)
        {
            ArtisanCategories addNew = new ArtisanCategories
            {
                CategoryName = model.CategoryName,
                Description = model.Description,
                CreatedDate = DateTime.Now
            };

            var isAdded = await _artisanCatergoryRepository.CreateAsync(addNew);

            return CreatedAtAction(nameof(GetThisCategory), new { id = isAdded.Id }, new { status = HttpStatusCode.Created, message = isAdded });
        }

        // PUT: api/ArtisanCategory/5
        [HttpPut(ApiRoute.Category.Update)]
        public async Task<IActionResult> Put(int id, [FromBody] CatergoryRequest model)
        {
            ArtisanCategories thisCategory = await _artisanCatergoryRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (thisCategory != null)
            {
                thisCategory.CategoryName = model.CategoryName;
                thisCategory.Description = model.Description;

                await _artisanCatergoryRepository.UpdateAsync(thisCategory);

                return Ok(new { status = HttpStatusCode.OK, message = thisCategory });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No record  exist for the category specified" });
        }
    }
}
