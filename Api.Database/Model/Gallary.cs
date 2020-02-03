using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Gallary
    {
        public int Id { get; set; }
        public string ArtisanEmail { get; set; }
        public string JobName { get; set; }
        public string Descr { get; set; }
        public string PicturePath { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Artisan ArtisanEmailNavigation { get; set; }
    }
}
