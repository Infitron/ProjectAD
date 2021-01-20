using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Lga
    {
        public Lga()
        {
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string Lga1 { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
