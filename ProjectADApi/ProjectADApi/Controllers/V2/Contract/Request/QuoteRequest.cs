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
        public decimal WorkmanShip { get; set; }
        public decimal Total { get; set; }
        public int BookingId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? OrderDate { get; set; } = DateTime.Now;

    }
}
