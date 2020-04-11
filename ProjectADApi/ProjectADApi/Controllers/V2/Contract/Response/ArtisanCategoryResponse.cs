using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class ArtisanCategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string SubCategories { get; set; }
        public DateTime? CreatedDate { get; set; }

       // public virtual ICollection<Artisan> Artisan { get; set; }
    }
}
