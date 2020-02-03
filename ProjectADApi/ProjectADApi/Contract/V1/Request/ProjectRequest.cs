using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ProjectRequest
    {
      
        public string ArtisanEmail { get; set; }
        public string ClientEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectName { get; set; }
        public int BookingId { get; set; }
        public DateTime? CreationDate { get; set; }

        //public virtual Booking Booking { get; set; }
        //public virtual ICollection<Quote> Quote { get; set; }
        //public virtual ICollection<Rating> Rating { get; set; }
    }
}
