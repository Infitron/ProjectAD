using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Response
{
    public class LocationResponse
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual Lov Status { get; set; }
       // public virtual ICollection<Artisan> Artisan { get; set; }
    }
}
