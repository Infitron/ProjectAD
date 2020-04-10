using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class QuoteRequest
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public int ClientId { get; set; }
        public string Item { get; set; }
        public string Descr { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Vat { get; set; }
        public string Address1 { get; set; }
        public int BookingId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual Booking Booking { get; set; }
        //public virtual Client Client { get; set; }
        //public virtual Artisan IdNavigation { get; set; }
        //public virtual Lov OrderStatus { get; set; }
        //public virtual ICollection<Projects> Projects { get; set; }
    }
}
