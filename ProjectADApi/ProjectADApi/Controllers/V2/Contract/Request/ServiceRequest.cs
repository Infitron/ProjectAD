using ProjectADApi.ApiConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class ServiceRequest
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Artisan Id Cannot be empty")]
       
        public int ArtisanId { get; set; }
       
        [Required(ErrorMessage = "ServiceName Cannot be empty")]
        public string ServiceName { get; set; }
        
        public string Descriptions { get; set; }
        
        public int StatusId { get; set; } = (int)AppStatus.Active;
        
        [Required(ErrorMessage = "Category Id Cannot be empty")]
        public int CategoryId { get; set; } 
        
        [Required(ErrorMessage = "SubCategory Id Cannot be empty")]        
        public int SubCategoryId { get; set; }
       
        public int? LocationId { get; set; }
        [Required(ErrorMessage = "Lg Id Cannot be empty")]
        
        public int LgaId { get; set; }
        
        public string Image { get; set; }
        
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "State Cannot be empty")]
        public int StateId { get; set; }

    }
}
