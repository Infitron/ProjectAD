//using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ArCatergoryRequest
    {
        
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

       // public virtual ICollection<Artisan> Artisan { get; set; }
    }
}
