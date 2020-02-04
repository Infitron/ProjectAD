using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Gallary
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string JobName { get; set; }
        public string Descr { get; set; }
        public string PicturePath { get; set; }
        public DateTime JobDate { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Artisan Artisan { get; set; }
        public virtual Projects Project { get; set; }
    }
}
