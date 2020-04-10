using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Services
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Artisan Artisan { get; set; }
        public virtual Lov Status { get; set; }
    }
}
