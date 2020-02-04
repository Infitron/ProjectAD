using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ArtisanId { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Rating1 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ProjectId { get; set; }

        public virtual Artisan Artisan { get; set; }
        public virtual Client Client { get; set; }
        public virtual Projects Project { get; set; }
    }
}
