using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Projects
    {
        public Projects()
        {
            Gallary = new HashSet<Gallary>();
            PaymentHistory = new HashSet<PaymentHistory>();
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string ProjectName { get; set; }
        public int QuoteId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Artisan Artisan { get; set; }
        public virtual Client Client { get; set; }
        public virtual Quote Quote { get; set; }
        public virtual ICollection<Gallary> Gallary { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
