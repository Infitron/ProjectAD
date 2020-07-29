using Api.Database.Core;
using Api.Database.Implementation;
using Api.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class SubCategoryResponse
    {
        private projectadContext _projectadContext = new projectadContext();
        IRepository<ArtisanCategories> _categoryRepository;
        public SubCategoryResponse() => _categoryRepository = new Api.Database.Implementation.Repository<ArtisanCategories>(_projectadContext);
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Category => _categoryRepository.GetByAsync(x => x.Id.Equals(CategoryId)).FirstAsync().Result.CategoryName;
    }
}
