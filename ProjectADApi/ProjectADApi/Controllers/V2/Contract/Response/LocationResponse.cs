using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class LocationResponse
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Area { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

       // public Lov Status { get; set; }
        public List<ArtisanResponse> Artisan { get; set; }
        public List<ServiceResponse> Services { get; set; }
    }
}
