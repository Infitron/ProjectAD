using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ServiceLov
    {
        public ServiceLov()
        {
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
