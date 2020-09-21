using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Data;
using Api.Database.Model;
using AutoMapper;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [Authorize]
    public class SubCategoryController : ControllerBase
    {
        readonly private IRepository<ArtisanSubCategory> _artisanSubCatergoryRepository;
        private readonly IMapper _mapper;
        readonly bluechub_ProjectADContext dbContext;

        public SubCategoryController(IRepository<ArtisanSubCategory> artisanSubCatergoryRepository, IMapper mapper, bluechub_ProjectADContext BbContext)
        {
            _artisanSubCatergoryRepository = artisanSubCatergoryRepository;
            _mapper = mapper;
            dbContext = BbContext;
        }

        // GET: api/ArSubCategory
        [HttpGet(ApiRoute.SubCategory.GetAll)]
        public async Task<IActionResult> AllSubCategory()
        {
            IEnumerable<ArtisanSubCategory> allSubCategory = await _artisanSubCatergoryRepository.GetAllAsync();

            if (allSubCategory.Any())
            {
                List<SubCategoryResponse> subCategory = _mapper.Map<List<SubCategoryResponse>>(allSubCategory);
                return Ok(new { status = HttpStatusCode.OK, message = subCategory });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }


        // GET: api/ArSubCategory/5
        [HttpGet()]
        [Route(ApiRoute.SubCategory.GetAllSub)]
        public async Task<IActionResult> GetAllSub(int CategoryId)
        {
            // ArtisanSubCategory thisSubCategory = await _artisanSubCatergoryRepository.GetByIdAsync(Cat);
           // bool isCatId = int.TryParse(CategoryId, out int catid);

            //if(isCatId)           
            //{
            //SubCategoryResponse subCategory = _mapper.Map<SubCategoryResponse>(thisSubCategory);

            List<SubCategoryResponse> subCategory = _mapper.Map<List<SubCategoryResponse>>(await
                                                   (from subs in dbContext.ArtisanSubCategory
                                                    where subs.CategoryId == CategoryId
                                                    select subs).ToListAsync());

            if (subCategory.Any()) return Ok(new { status = HttpStatusCode.OK, message = subCategory });
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });


            //}
            //return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid category id format" });            
        }

        // GET: api/ArSubCategory/5
        [HttpGet(ApiRoute.SubCategory.Get)]
        public async Task<IActionResult> ThisSubCategory(int id)
        {
            ArtisanSubCategory thisSubCategory = await _artisanSubCatergoryRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (thisSubCategory != null)
            {
                SubCategoryResponse subCategory = _mapper.Map<SubCategoryResponse>(thisSubCategory);
                return Ok(new { status = HttpStatusCode.OK, message = subCategory });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // POST: api/ArSubCategory
        [HttpPost(ApiRoute.SubCategory.Create)]
        public async Task<IActionResult> Post([FromBody] SubCategoryRequest model)
        {
            ArtisanSubCategory newSubCategory = _mapper.Map<ArtisanSubCategory>(model);

            newSubCategory = await _artisanSubCatergoryRepository.CreateAsync(newSubCategory);

            SubCategoryResponse response = _mapper.Map<SubCategoryResponse>(newSubCategory);

            return CreatedAtAction(nameof(ThisSubCategory), new { id = newSubCategory.Id }, new { status = HttpStatusCode.Created, message = response });
        }

        // PUT: api/ArSubCategory/5
        [HttpPut(ApiRoute.SubCategory.Update)]
        public async Task<IActionResult> Put(int id, [FromBody] SubCategoryRequest model)
        {
            ArtisanSubCategory updateSubCategory = await _artisanSubCatergoryRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (updateSubCategory == null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "We could find the artisan sub-category you are trying to modify" });


            updateSubCategory.Id = id;
            updateSubCategory.SubCategories = model.Name;
            updateSubCategory.Descr = model.Description;

            updateSubCategory = await _artisanSubCatergoryRepository.UpdateAsync(updateSubCategory);

            SubCategoryResponse response = _mapper.Map<SubCategoryResponse>(updateSubCategory);

            return Ok(new { status = HttpStatusCode.Created, message = response });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
