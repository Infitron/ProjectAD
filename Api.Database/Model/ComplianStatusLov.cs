using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ComplianStatusLov
    {
        public ComplianStatusLov()
        {
            Complainant = new HashSet<Complainant>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Complainant> Complainant { get; set; }
    }
}
