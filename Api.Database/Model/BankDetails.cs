using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class BankDetails
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string Bvn { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
