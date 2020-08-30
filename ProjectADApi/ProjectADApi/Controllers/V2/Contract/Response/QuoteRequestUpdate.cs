using ProjectADApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class QuoteRequestUpdate
    {
        public List<QuoteItem> Item { get; set; }
        public decimal? Discount { get; set; }
        public string Address1 { get; set; }
        public int BookingId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int OrderStatusId { get; set; }
        public int QuoteStatusId { get; set; }
    }
}
