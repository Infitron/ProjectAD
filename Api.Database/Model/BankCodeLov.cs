using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class BankCodeLov
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Bankcode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
