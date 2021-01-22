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
            public const string Get = Base + "/artisan/{UserId}";
            public const string Create = Base + "/artisan";
            public const string Update = Base + "/artisan/{id}";
            public const string Delete = Base + "/artisan/{id}";
            public const string Upgrade = Base + "/artisan/{id}";
           // public const string ByUserId = Base + "/artisan/{user}";
        }

        public static class Search
        {
            public const string Get = Base + "/Search";
        }

        public static class Service
        {
            public const string GetAll = Base + "/Service";
            public const string Get = Base + "/Service/{id}";
            public const string GetService = Base + "/Service/AllService/{ArtisanId}";
            public const string Create = Base + "/Service";
            public const string Update = Base + "/Service/{id}";
            public const string Delete = Base + "/Service/{id}";
        }
        public static class Category
        {
            public const string GetAll = Base + "/Category";
            public const string Get = Base + "/Category/{id}";
            public const string Create = Base + "/Category";
            public const string Update = Base + "/Category/{id}";
            public const string Delete = Base + "/Category/{id}";
        }

        public static class SubCategory
        {
            public const string GetAll = Base + "/SubCategory";
            public const string GetAllSub = Base + "/SubCategory/GetSubs";
            public const string Get = Base + "/SubCategory/{id}";
            public const string Create = Base + "/SubCategory";
            public const string Update = Base + "/SubCategory/{id}";
            public const string Delete = Base + "/SubCategory/{id}";
        }

        public static class Order
        {
            public const string GetAll = Base + "/Order";
            public const string GetOrder = Base + "/Order/Artisan/{ArtisanId}";
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
            public const string Get = Base + "/Client/{UserId}";
            public const string Create = Base + "/Client";
            public const string Update = Base + "/Client/{id}";
            public const string Delete = Base + "/Client/{id}";
        }

        public static class Article
        {
            public const string GetAll = Base + "/Article";
            public const string Get = Base + "/Article/{id}";
            public const string Create = Base + "/Article";
            public const string Update = Base + "/Article/{id}";
            public const string Delete = Base + "/Article/{id}";
        }

        public static class Quote
        {
            public const string GetAll = Base + "/Quote/ArtisanId";
            public const string Get = Base + "/Quote/BookingId";
            public const string Create = Base + "/Quote";
            public const string Update = Base + "/Quote/{id}";
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

        public static class ArtisanService
        {
            public const string GetAll = Base + "/ArtisanService/{ArtisantId}";
            public const string GetThisArtisanService = Base + "/ArtisanService";
            public const string Create = Base + "/ArtisanService";
            public const string Update = Base + "/ArtisanService/{id}";
            public const string Delete = Base + "/ArtisanService/{id}";
        }

        public static class Location
        {
            public const string GetAll = Base + "/Location";
            public const string Get = Base + "/Location/{id}";
            public const string Create = Base + "/Location";
            public const string Update = Base + "/Location";
            public const string Delete = Base + "/Location/{id}";
        }

        public static class StateLocalGovernment
        {
            public const string ThisState = Base + "/StateLocalGovernment/ThisState/{stateId}";
            public const string AllState = Base + "/StateLocalGovernment/State/AllState";
            public const string AllLocalGovernment = Base + "/StateLocalGovernment/LocalGoverment/AllLocalGovernment/{StateId}";

        }

        public static class Complaint
        {
            public const string GetAll = Base + "/Complaint";
            public const string GetByArtisan = Base + "/Complaint/Artisan/{ArtisanId}";
            public const string Get = Base + "/Complaint/{ComplaintId}";
            public const string GetByStatus = Base + "/Complaint/Status/{StatusId}";
            public const string Create = Base + "/Complaint";
            public const string Update = Base + "/Complaint/{ComplaintId}";
            public const string Delete = Base + "/Complaint/{id}";
        }

        public static class Upgrade
        {
            public const string GetAll = Base + "/Updgrade";
            public const string CallBack = Base + "/Updgrade/Callback";
            public const string GetPending = Base + "/Updgrade/Pending";
            public const string GetByStatus = Base + "/Updgrade/Status/{StatusId}";
            public const string verify = Base + "/Updgrade/Request/VerificationType";
            public const string Create = Base + "/Updgrade/Request";
          
        }

    }
}
