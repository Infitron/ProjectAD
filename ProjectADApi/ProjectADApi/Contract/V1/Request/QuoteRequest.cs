using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class QuoteRequest
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string ArtisanEmail { get; set; }

        [Required(ErrorMessage ="Please specify item")]
        public string Item { get; set; }

        
        public string Descr { get; set; }

       
        public double Quantity { get; set; }

        [Required(ErrorMessage = "Please specify the price")]
        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Vat { get; set; }

        public string Address1 { get; set; }

        //public virtual Artisan ArtisanEmailNavigation { get; set; }
        //public virtual Client ClientEmailNavigation { get; set; }
    }
}
