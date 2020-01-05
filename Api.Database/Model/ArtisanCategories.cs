using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArtisanCategories
    {
        public ArtisanCategories()
        {
            Registration = new HashSet<Registration>();
        }

        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescr { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
