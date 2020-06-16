using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArtisanCategories
    {
        public ArtisanCategories()
        {
            Artisan = new HashSet<Artisan>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Artisan> Artisan { get; set; }
    }
}
