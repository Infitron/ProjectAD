using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class ArCatergoryRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescr { get; set; }
        public string SubCategories { get; set; }
    }
}
