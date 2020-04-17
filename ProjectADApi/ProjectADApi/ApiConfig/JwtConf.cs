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

    public enum AppStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Active = 4,
        Dismissed = 5,
        Resolved = 6,
        Completed = 7,
        Submitted = 8,
        Initiated = 9,
        Suspended = 10
    }

    public enum AppUsers
    {
        Artisan,
        Client,
        Admin       
    }
}
