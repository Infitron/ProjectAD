using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class AuditTrail
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string Os { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string MacAddress { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }
        public string CreatedTime { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }

        public virtual UserLogin User { get; set; }
    }
}
