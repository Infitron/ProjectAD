using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract
{
    public static class ApiRoute
    {
        private const string Root = "api";
        private const string Version1 = "v1.1";
        private const string Base = Root + "/" + Version1;

        public static class Account
        {
            public const string Login = Base + "/Account";
           
        }
    }
}
