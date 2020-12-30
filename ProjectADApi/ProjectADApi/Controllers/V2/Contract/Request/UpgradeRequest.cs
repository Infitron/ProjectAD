using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class UpgradeRequest
    {
        public string Address { get; set; }
        public string Account { get; set; }
        public string BVN { get; set; }
        public string NIN { get; set; }
        public string PassportNumber { get; set; }
        public string Level { get; set; }
    }
}
