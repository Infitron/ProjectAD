using ProjectADApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class QuoteRequestUpdate
    {
        public List<QuoteItem> Item { get; set; }
        public decimal? Discount { get; set; }       
        public int BookingId { get; set; }           
        public int QuoteStatusId { get; set; }
        public decimal? WorkmanShip { get; set; }
        public decimal? Total { get; set; }

    }
}
