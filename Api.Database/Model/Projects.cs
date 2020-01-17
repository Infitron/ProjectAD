using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Projects
    {
        public int Id { get; set; }
        public string ArtisanEmail { get; set; }
        public string ClientEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectName { get; set; }
        public int BookingId { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Client ClientEmailNavigation { get; set; }
    }
}
