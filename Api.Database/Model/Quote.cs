using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Quote
    {
        public Quote()
        {
            Projects = new HashSet<Projects>();
        }

        public int Id { get; set; }
        public string Item { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Vat { get; set; }
        public int BookingId { get; set; }
        public int QuoteStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? WorkmanShip { get; set; }
        public decimal? Total { get; set; }

        public virtual ICollection<Projects> Projects { get; set; }
    }
}
