using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Lov
    {
        public Lov()
        {
            Article = new HashSet<Article>();
            Complaint = new HashSet<Complaint>();
            Location = new HashSet<Location>();
            Services = new HashSet<Services>();
            UserLogin = new HashSet<UserLogin>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Article> Article { get; set; }
        public virtual ICollection<Complaint> Complaint { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Services> Services { get; set; }
        public virtual ICollection<UserLogin> UserLogin { get; set; }
    }
}
