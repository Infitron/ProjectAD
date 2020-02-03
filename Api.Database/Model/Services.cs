using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Services
    {
        public int Id { get; set; }
        public string ArtisanEmail { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
        public virtual ServiceLov Status { get; set; }
    }
}
