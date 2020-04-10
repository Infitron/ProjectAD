//using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ProjectRequest
    {

        public int ArtisanId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string ProjectName { get; set; }
        public int QuoteId { get; set; }
        public DateTime? CreationDate { get; set; }

        //public virtual Artisan Artisan { get; set; }
        //public virtual Client Client { get; set; }
        //public virtual Quote Quote { get; set; }
        //public virtual ICollection<Gallary> Gallary { get; set; }
        //public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        //public virtual ICollection<Rating> Rating { get; set; }

        //public virtual Booking Booking { get; set; }
        //public virtual ICollection<Quote> Quote { get; set; }
        //public virtual ICollection<Rating> Rating { get; set; }
    }
}
