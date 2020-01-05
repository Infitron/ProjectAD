using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string ArtisanEmail { get; set; }
        public string Messages { get; set; }
        public DateTime MsgDate { get; set; }
        public TimeSpan MsgTime { get; set; }

        public virtual Registration UserEmailNavigation { get; set; }
    }
}
