using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class PaymentHistory
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ArtEmail { get; set; }
        public string UserEmail { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PayDate { get; set; }
        public string PaymentType { get; set; }

        public virtual Projects Project { get; set; }
    }
}
