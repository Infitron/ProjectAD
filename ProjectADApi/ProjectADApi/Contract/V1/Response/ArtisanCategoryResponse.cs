using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Response
{
    public class ArtisanCategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string SubCategories { get; set; }
        public DateTime? CreatedDate { get; set; }

        
        //public virtual ICollection<Artisan> Artisan { get; set; }
    }
}
