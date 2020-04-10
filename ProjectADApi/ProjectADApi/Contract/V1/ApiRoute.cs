using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1
{
    public static class ApiRoute
    {
        private const string Root = "api";
        private const string Version1 = "v1";
        private const string Base = Root + "/" + Version1;

        public static class Artisan
        {
            public const string GetAll = Base + "/artisan";
            public const string Get = Base + "/artisan/{id}";
            public const string Create = Base + "/artisan";
            public const string Update = Base + "/artisan/{id}";
            public const string Delete = Base + "/artisan/{id}";
        }

        public static class Order
        {
            public const string GetAll = Base + "/Order";
            public const string Get = Base + "/Order/{id}";
            public const string Create = Base + "/Order";
            public const string Update = Base + "/Order";
            public const string Delete = Base + "/Order/{id}";
        }

        public static class Rating
        {
            public const string GetAll = Base + "/Rating";
            public const string Get = Base + "/Rating/{id}";
            public const string Create = Base + "/Rating";
            public const string Update = Base + "/Rating/{id}";
            public const string Delete = Base + "/Rating/{id}";
        }

        public static class Client
        {
            public const string GetAll = Base + "/Client";
            public const string Get = Base + "/Client/{id}";
            public const string Create = Base + "/Client";
            public const string Update = Base + "/Client/{id}";
            public const string Delete = Base + "/Client/{id}";
        }

        public static class Account
        {
            public const string Login = Base + "/Account";
            public const string Register = Base + "/Account";            
        }

        public static class ACategory
        {
            public const string GetAll = Base + "/ACategory";
            public const string Get = Base + "/ACategory/{id}";
            public const string Create = Base + "/ACategory";
            public const string Update = Base + "/ACategory/{id}";
            public const string Delete = Base + "/ACategory/{id}";
        }

        public static class Article
        {
            public const string GetAll = Base + "/Article";
            public const string Get = Base + "/Article/{id}";
            public const string Create = Base + "/Article";
            public const string Update = Base + "/Article{id}";
            public const string Delete = Base + "/Article/{id}";
        }

        public static class Quote
        {
            public const string GetAll = Base + "/Quote";
            public const string Get = Base + "/Quote/{projectId}";
            public const string Create = Base + "/Quote";
            public const string Update = Base + "/Quote";
            public const string Delete = Base + "/Quote/{id}";
        }

        public static class Project
        {
            public const string GetAll = Base + "/Project";
            public const string Get = Base + "/Project/{id}";
            public const string Create = Base + "/Project";
            public const string Update = Base + "/Project";
            public const string Delete = Base + "/Project/{id}";
        }

        public static class BankDetail
        {
            public const string GetAll = Base + "/BankDetail";
            public const string Get = Base + "/BankDetail/{id}";
            public const string Create = Base + "/BankDetail";
            public const string Update = Base + "/BankDetail";
            public const string Delete = Base + "/BankDetail/{id}";
        }

        public static class Search
        {
            public const string Get = Base + "/Search";
        }

        public static class Service
        {
            public const string GetAll = Base + "/Service";
            public const string Get = Base + "/Service/{id}";
            public const string Create = Base + "/Service";
            public const string Update = Base + "/Service";
            public const string Delete = Base + "/Service/{id}";
        }

        public static class Location
        {
            public const string GetAll = Base + "/Location";
            public const string Get = Base + "/Location/{id}";
            public const string Create = Base + "/Location";
            public const string Update = Base + "/Location";
            public const string Delete = Base + "/Location/{id}";
        }

        public static class Payment
        {
            public const string InitCardPay = Base + "/Payment";
            public const string AuthenticatePin = Base + "/Payment/authPin";
        }

        public static class BankCode
        {
            public const string GetAll = Base + "/BankCode";
            public const string Get = Base + "/BankCode/{id}";
            public const string Create = Base + "/BankCode";
            public const string Update = Base + "/BankCode/{id}";
            public const string Delete = Base + "/BankCode/{id}";
        }

        public static class Gallery
        {
            public const string GetAll = Base + "/Gallery/{UserId}";
            public const string GetAllProjectGallery = Base + "/Gallery";
            public const string Create = Base + "/Gallery";
            //public const string Update = Base + "/Gallery/{id}";
            //public const string Delete = Base + "/Gallery/{id}";
        }


    }
}
