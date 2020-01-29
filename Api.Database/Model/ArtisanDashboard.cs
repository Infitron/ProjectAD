using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArtisanDashboard
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string ProductImagePath { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Artisan EmailAddressNavigation { get; set; }
    }
}
