﻿using ProjectADApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class QuoteResponse
    {
        public int Id { get; set; }

        public string Artisan { get; set; }
        public string Client { get; set; }

        public List<QuoteItem> Item { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Vat { get; set; }
        public string Address1 { get; set; }

        public int BookingId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string QuoteStatus { get; set; }
        public string OrderStatus { get; set; }
    }
}