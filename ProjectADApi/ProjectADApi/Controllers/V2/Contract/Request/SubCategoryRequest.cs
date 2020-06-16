using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class SubCategoryRequest
    {
        public int Id { get; set; }
        public string SubCategories { get; set; }
        public string Descr { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
