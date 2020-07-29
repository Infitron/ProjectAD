using Api.Database.Core;
using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class ComplaintResponse
    {
      
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtisanId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusId { get; set; }
        public DateTime DateResolved { get; set; }

        public ArtisanResponse Artisan { get; }
    }
}
