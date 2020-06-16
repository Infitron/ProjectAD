//using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class CatergoryRequest
    {
        
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

       // public virtual ICollection<Artisan> Artisan { get; set; }
    }
}
