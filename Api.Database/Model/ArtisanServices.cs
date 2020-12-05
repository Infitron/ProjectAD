using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArtisanServices
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
