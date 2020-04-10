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
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your account name")]   
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Please enter your account numer")]
        [MaxLength(10)]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Please enter your bank code")]
        [MaxLength(6)]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "Please enter your bank code")]
        [MaxLength(11)]
        public string Bvn { get; set; }

        public DateTime? CreatedDate { get; set; }

        // public virtual Artisan EmailAddressNavigation { get; set; }      

        //public virtual Artisan Artisan { get; set; }
        //public virtual BankCodeLov BankCodeNavigation { get; set; }
    }
}
