using ProjectADApi.ApiConfig;
using ProjectADApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class QuoteRequest
    {       
        
        public List<QuoteItem> Item { get; set; }        
        public decimal? Discount { get; set; }
        public string Address1 { get; set; } 
        public int BookingId { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public int Id { get; set; }
        //public DateTime OrderDate { get; set; } = DateTime.Now;
        //public int OrderStatusId { get; set; } = (int)AppStatus.Initiated;
        //public decimal? Vat { get; set; } 
        //public virtual Booking Booking { get; set; }
        //public virtual Client Client { get; set; }
        //public virtual Artisan IdNavigation { get; set; }
        //public virtual Lov OrderStatus { get; set; }
        //public virtual ICollection<Projects> Projects { get; set; }
    }
}
