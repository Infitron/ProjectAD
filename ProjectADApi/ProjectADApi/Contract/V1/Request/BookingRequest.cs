//using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.Request
{
    public class BookingRequest
    {
        public int Id { get; set; }
        public int ClienId { get; set; }
        public int ArtisanId { get; set; }
        public string Messages { get; set; }
        public DateTime MsgDate { get; set; }
        public TimeSpan MsgTime { get; set; }
        public int? ServiceId { get; set; }
        public int? QuoteId { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual Artisan Artisan { get; set; }
        //public virtual Client Clien { get; set; }
        //public virtual Quote Quote { get; set; }
    }
}
