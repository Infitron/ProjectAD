using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class PaymentHistory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ArtisanId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PayDate { get; set; }
        public string PaymentType { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Projects Project { get; set; }
    }
}
