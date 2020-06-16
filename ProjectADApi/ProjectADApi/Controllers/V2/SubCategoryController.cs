using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubCategoryController : ControllerBase
    {
        readonly private IRepository<ArtisanSubCategory> _artisanSubCatergoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryController(IRepository<ArtisanSubCategory> artisanSubCatergoryRepository, IMapper mapper)
        {
            _artisanSubCatergoryRepository = artisanSubCatergoryRepository;
            _mapper = mapper;
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
        [HttpGet(ApiRoute.SubCategory.Get)]
        public async Task<IActionResult> ThisSubCategory(int id)
        {
            ArtisanSubCategory thisSubCategory = await _artisanSubCatergoryRepository.GetByIdAsync(id);

            if (thisSubCategory != null)
            {
                SubCategoryResponse subCategory = _mapper.Map<SubCategoryResponse>(thisSubCategory);
                return Ok(new { status = HttpStatusCode.OK, message = subCategory });
            }

            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // POST: api/ArSubCategory
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/ArSubCategory/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
