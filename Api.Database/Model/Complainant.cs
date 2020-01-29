using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Complainant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtisanEmail { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusId { get; set; }
        public DateTime DateResolved { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
        public virtual ComplianStatusLov Status { get; set; }
    }
}
