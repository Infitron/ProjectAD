//using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.Request
{
    public class RatingRequest
    {
        public int ClientId { get; set; }
        public int ArtisanId { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Rating1 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ProjectId { get; set; }

        //public virtual Artisan ArtisanEmailNavigation { get; set; }
        //public virtual Client ClientEmailNavigation { get; set; }
    }
}
