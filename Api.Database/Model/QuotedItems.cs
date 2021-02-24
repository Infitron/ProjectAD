using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class QuotedItems
    {
        public int Id { get; set; }
        public int QouteId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnityPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
