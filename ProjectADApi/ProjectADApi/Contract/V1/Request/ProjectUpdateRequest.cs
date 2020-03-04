using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ProjectUpdateRequest
    {
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }       
        public int QuoteId { get; set; }
    }
}
