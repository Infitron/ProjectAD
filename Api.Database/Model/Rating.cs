using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Rating
    {
        public long Id { get; set; }
        public string UserEmail { get; set; }
        public string ArtisanEmail { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public long Rating1 { get; set; }

        public virtual Registration UserEmailNavigation { get; set; }
    }
}
