using ProjectADApi.ApiConfig;
using ProjectADApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class QuoteResponse
    {
        public QuoteResponse()
        {

        }
       
        public int Id { get; set; }
        //public string Artisan { get; set; }
        //public string Client { get; set; }
        public List<QuoteItem> Item { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Vat { get; set; }
        public decimal WorkmanShip { get; set; }
        public decimal Total { get; set; }
        public int BookingId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int QuoteStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string QuoteStatus => Enum.GetName(typeof(AppStatus),  value: QuoteStatusId);
        public string OrderStatus => Enum.GetName(typeof(AppStatus), OrderStatusId);


    }
}
