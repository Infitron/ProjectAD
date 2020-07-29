using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class ServiceRequest
    {
        
        public int ArtisanId { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
        public int StatusId { get; set; }
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? LgaId { get; set; }
        public string Image { get; set; }
        public DateTime? CreationDate { get; set; }

        
    }
}
