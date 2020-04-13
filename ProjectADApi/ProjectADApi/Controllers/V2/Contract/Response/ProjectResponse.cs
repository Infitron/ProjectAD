using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string ProjectName { get; set; }
        public int QuoteId { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
