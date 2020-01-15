using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Booking
    {
        public Booking()
        {
            Projects = new HashSet<Projects>();
        }

        public int Id { get; set; }
        public string ClientEmail { get; set; }
        public string ArtisanEmail { get; set; }
        public string Messages { get; set; }
        public DateTime MsgDate { get; set; }
        public TimeSpan MsgTime { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
        public virtual Client ClientEmailNavigation { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
