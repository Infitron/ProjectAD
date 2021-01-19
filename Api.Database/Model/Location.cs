using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Location
    {
        public Location()
        {
            Artisan = new HashSet<Artisan>();
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Area { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Lov Status { get; set; }
        public virtual ICollection<Artisan> Artisan { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
