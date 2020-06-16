using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class ServiceRequest
    {       
        public int UserId { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
       // public int StatusId { get; set; }
       // public DateTime? CreationDate { get; set; }

        //public virtual Artisan Artisan { get; set; }
        //public virtual Lov Status { get; set; }
    }
}
