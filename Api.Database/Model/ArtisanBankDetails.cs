using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArtisanBankDetails
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public decimal AccountNumber { get; set; }
        public string BankName { get; set; }
        public decimal Bvn { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Artisan EmailAddressNavigation { get; set; }
    }
}
