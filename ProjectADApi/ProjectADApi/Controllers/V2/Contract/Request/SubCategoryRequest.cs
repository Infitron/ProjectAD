using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class SubCategoryRequest
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
       // public DateTime? CreationDate { get; set; }
    }
}
