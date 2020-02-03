using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class BankDetaildRequest
    {
        [Required(ErrorMessage ="Please enter your email")]
        [EmailAddress(ErrorMessage ="please enter a valid email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your account name")]   
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Please enter your account numer")]
        [MaxLength(10)]
        public decimal AccountNumber { get; set; }

        [Required(ErrorMessage = "Please enter your bank code")]
        [MaxLength(6)]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Please enter your bank code")]
        [MaxLength(11)]
        public decimal Bvn { get; set; }

        public DateTime? CreatedDate { get; set; }

       // public virtual Artisan EmailAddressNavigation { get; set; }
    }
}
