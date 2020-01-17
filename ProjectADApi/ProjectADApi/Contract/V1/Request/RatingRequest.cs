using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.Request
{
    public class RatingRequest
    {        
        public string ClientEmail { get; set; }
        public string ArtisanEmail { get; set; }       
        public string Description { get; set; }
        public string Comment { get; set; }
        public int Rating1 { get; set; }
        public DateTime JobEndDate { get; set; }
        public DateTime JobStartDate { get;  set; }

        //public virtual Artisan ArtisanEmailNavigation { get; set; }
        //public virtual Client ClientEmailNavigation { get; set; }
    }
}
