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
            public const string Login = Base + "/Account/Login";
            public const string Update = Base + "/Account/UpdateStatus";
            public const string Register = Base + "/Account/Register";
            public const string AllUser = Base + "/Account/AllUser";
            public const string ForgotPassword = Base + "/Account/ForgotPassword";
            public const string ResetPassword = Base + "/Account/ResetPassword";
        }

        public static class Artisan
        {
            public const string GetAll = Base + "/artisan";
            public const string Get = Base + "/artisan/{id}";
            public const string Create = Base + "/artisan";
            public const string Update = Base + "/artisan/{id}";
            public const string Delete = Base + "/artisan/{id}";
        }

        public static class Search
        {
            public const string Get = Base + "/Search";
        }
    }
}
