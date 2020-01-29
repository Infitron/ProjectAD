using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Rating
    {
        public int Id { get; set; }
        public string ClientEmail { get; set; }
        public string ArtisanEmail { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Rating1 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ProjectId { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
        public virtual Client ClientEmailNavigation { get; set; }
        public virtual Projects Project { get; set; }
    }
}
