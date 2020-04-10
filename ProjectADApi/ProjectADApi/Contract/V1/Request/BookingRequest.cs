//using Api.Database.Model;
using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.Request
{
    public class BookingRequest
    {
       
        public int ClientUserId { get; set; }       
        public string Messages { get; set; }       
        public int ServiceId { get; set; }       

        //public virtual Artisan Artisan { get; set; }
        //public virtual Client Clien { get; set; }
        //public virtual ICollection<Quote> Quote { get; set; }
    }
}
