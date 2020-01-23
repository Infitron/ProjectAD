using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]

        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage ="Password Mismatch")]
        public string ConfrimNewPassword { get; set; }
    }
}
