using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class ServiceResponse
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string ServiceName { get; set; }
        public string Descriptions { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreationDate { get; set; }

       // public Artisan Artisan { get; set; }
        //public virtual Lov Status { get; set; }
    }
}
