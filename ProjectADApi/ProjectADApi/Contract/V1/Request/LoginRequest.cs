using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string  username { get; set; }
        public string password { get; set; }

    }
}
