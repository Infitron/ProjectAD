using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ServiceRequest
    {
       
        [Required]
        [EmailAddress]
        public string ArtisanEmail { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public string Descriptions { get; set; }

        [Required]
        public int StatusId { get; set; }       

        //public virtual Artisan ArtisanEmailNavigation { get; set; }
        //public virtual ServiceLov Status { get; set; }
    }
}
