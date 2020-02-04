using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Quote
    {
        public Quote()
        {
            Booking = new HashSet<Booking>();
            Projects = new HashSet<Projects>();
        }

        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string Item { get; set; }
        public string Descr { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Vat { get; set; }
        public string Address1 { get; set; }
        public int ProjectId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Artisan IdNavigation { get; set; }
        public virtual Lov OrderStatus { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
