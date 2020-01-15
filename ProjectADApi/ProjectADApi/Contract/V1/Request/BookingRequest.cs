using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.Request
{
    public class BookingRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ClientEmail { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string ArtisanEmail { get; set; }

        public string Messages { get; set; }
        
    }
}
