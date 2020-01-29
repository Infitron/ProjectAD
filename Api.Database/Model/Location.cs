using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Location
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
