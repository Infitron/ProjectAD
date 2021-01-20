using Api.Database.Core;
using Api.Database.Implementation;
using Api.Database.Model;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class ServiceResponse
    {
        //private bluechub_ProjectADContext _projectadContext = new bluechub_ProjectADContext();
       
        ////readonly IRepository<ArtisanSubCategory> _subCatRepository;
        ////readonly IRepository<Lga> _lgaRepository;
        //int _stateId;
        //int _statusId;
        //int _categoryId;
        //int _subcategoryId;
        //int _lgId;
        public ServiceResponse()
        {
            //_stateId = stateid;
            //_statusId = statusId;
            //_categoryId = categoryId;
            //_subcategoryId = subCateId;
            //_lgId = LgId;
            //_subCatRepository = new Repository<ArtisanSubCategory>(_projectadContext);
            //_lgaRepository = new Repository<Lga>(_projectadContext);
        }
            
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
        public string Status { get; set; } //Enum.GetName(typeof(AppStatus), _statusId);
        public string Category { get; set; }//=> AppDictionary.Category[_categoryId];
        public string SubCategory{ get; set; }// => _subCatRepository.GetByAsync(x => x.Id.Equals(_subcategoryId)).FirstOrDefaultAsync().Result.SubCategories;
        public int? LocationId { get; set; }
        public string LGArea { get; set; } //=> _lgaRepository.GetByAsync(x => x.Id.Equals(_lgId)).FirstOrDefaultAsync().Result.Lga1;
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }      

        public string State { get; set; } //=> AppDictionary.States[_stateId];

        //public ArtisanResponse Artisan { get; set; }
        //public Lov Status { get; set; }
        //public LocationResponse Location { get; set; }
        //public ArtisanCategoryResponse Category { get; set; }
    }


}
