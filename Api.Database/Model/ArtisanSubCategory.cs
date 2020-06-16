using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArtisanSubCategory
    {
        public int Id { get; set; }
        public string SubCategories { get; set; }
        public string Descr { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
