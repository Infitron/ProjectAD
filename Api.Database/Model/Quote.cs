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
        public string Address1 { get; set; }
        public int BookingId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? QuoteStatusId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Lov OrderStatus { get; set; }
        public virtual Lov QuoteStatus { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
