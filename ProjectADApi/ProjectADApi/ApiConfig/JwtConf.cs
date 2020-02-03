using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.ApiConfig
{
    public class JwtConf
    {
        public string SecretKey { get; set; }
    }

    public class AppVariable
    {
        public string BaseUrlPath { get; set; }
    }

    public  enum ApprovalStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
