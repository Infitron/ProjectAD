using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Services
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
        public int StatusId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? LgaId { get; set; }
        public string Image { get; set; }
        public DateTime? CreationDate { get; set; }
        public int StateId { get; set; }

        public virtual Artisan Artisan { get; set; }
        public virtual ArtisanCategories Category { get; set; }
        public virtual Lga Lga { get; set; }
        public virtual Location Location { get; set; }
        public virtual Lov Status { get; set; }
        public virtual ArtisanSubCategory SubCategory { get; set; }
    }
}
