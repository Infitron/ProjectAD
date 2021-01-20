using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class LocationRequest
    {
        public string State { get; set; }
        public string Lga { get; set; }
        public string Area { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
