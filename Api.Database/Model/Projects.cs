using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Projects
    {
        public Projects()
        {
            PaymentHistory = new HashSet<PaymentHistory>();
        }

        public long Id { get; set; }
        public string ArtEmail { get; set; }
        public string UserEmail { get; set; }
        public long ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectName { get; set; }
        public long BookingId { get; set; }

        public virtual Registration ArtEmailNavigation { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
    }
}
