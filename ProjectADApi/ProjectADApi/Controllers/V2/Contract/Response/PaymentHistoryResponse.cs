using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class PaymentHistoryResponse
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ArtisanId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PayDate { get; set; }
        public string PaymentType { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual Artisan Artisan { get; set; }
        //public virtual Client Client { get; set; }
        //public virtual Projects Project { get; set; }
    }
}
