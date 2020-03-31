using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V1.Contracts.Response
{
    public class BookingResponse
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ArtisanId { get; set; }
        public string ArtisanFullName { get; set; }
        public string ClientFullName { get; set; }
        public string Messages { get; set; }
        public DateTime MsgDate { get; set; }
        public TimeSpan MsgTime { get; set; }
        public int? ServiceId { get; set; }
        public int? QuoteId { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual Artisan Artisan { get; set; }
        //public virtual Client Clien { get; set; }
        //public virtual ICollection<Quote> Quote { get; set; }
    }
}
