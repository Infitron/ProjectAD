using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class GalleryRequest
    {
       
        public int userId { get; set; }
        public string JobName { get; set; }
        public string Descr { get; set; }
        public string PicturePath { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ProjectId { get; set; }

        // public virtual Artisan ArtisanEmailNavigation { get; set; }
    }
}
