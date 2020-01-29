using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class PaymentHistory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ArtisanEmail { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PayDate { get; set; }
        public string PaymentType { get; set; }
        public string ClientEmail { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
        public virtual Client ClientEmailNavigation { get; set; }
    }
}
