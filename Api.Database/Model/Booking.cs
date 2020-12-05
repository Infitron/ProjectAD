using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Booking
    {
        public Booking()
        {
            Quote = new HashSet<Quote>();
        }

        public int Id { get; set; }
        public int? ClienId { get; set; }
        public int? ArtisanId { get; set; }
        public string Messages { get; set; }
        public DateTime? MsgDate { get; set; }
        public TimeSpan? MsgTime { get; set; }
        public int? ServiceId { get; set; }
        public int? QuoteId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Quote> Quote { get; set; }
    }
}
