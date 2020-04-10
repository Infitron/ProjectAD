using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class LocationRequest
    {
        [Required]
        public string State { get; set; }
        [Required]
        public string Lga { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
