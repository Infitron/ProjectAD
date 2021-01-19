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
using ProjectADApi.Contract.V1.Response;

namespace ProjectADApi.Controllers.V1
{
    [ApiVersion("1", Deprecated =true)]
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
            {
                List<ArtisanCategoryResponse> allACategoryResponse = allCategory.Select(x => new ArtisanCategoryResponse
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
        [HttpGet(ApiRoute.ACategory.Get)]
        public async Task<IActionResult> GetThisCategory(int id)
        {
            ArtisanCategories thisCategory = await Task.Run(() => _artisanCatergoryRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefault());

            ArtisanCategoryResponse _thisCategory = new ArtisanCategoryResponse
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
        [HttpPost(ApiRoute.ACategory.Create)]
        public async Task<IActionResult> Post([FromBody] ArCatergoryRequest model)
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
        [HttpPut(ApiRoute.ACategory.Update)]
        public async Task<IActionResult> Put(int id, [FromBody] ArCatergoryRequest model)
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
