using Api.Database.Model;
using ProjectADApi.Contract.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class ComplaintRequest
    {
       
        public string Title { get; set; }
        public int ArtisanId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int StatusId { get; set; }
        public DateTime DateResolved { get; set; } = DateTime.Now;

    }
}
