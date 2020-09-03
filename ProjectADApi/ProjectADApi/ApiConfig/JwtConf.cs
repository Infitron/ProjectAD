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
        public string VAT { get; set; }
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
        Suspended = 10,
        Accepted = 11,
        Raised = 12,
        Adjusted = 13
    }

    public enum AppUsers
    {
        Artisan,
        Client,
        Admin
    }

    public  class AppDictionary
    {
        public static  Dictionary<int, string> States = new Dictionary<int, string> { { 0, "State Unknown" }, { 1, "Abia" }, {2, "Adamawa" },  {3,"Akwa Ibom"}, {4,"Anambra" },{ 5, "Bauchi"}, {6,"Bayelsa" }, { 7,"Benue" },{8, "Borno" }, { 9, "Cross River" }, { 10, "Delta" }, { 11, "Ebonyi"}, { 12, "Edo" }, { 13, "Ekiti" },  { 14, "Enugu" }, { 15, "Gombe"}, { 16, "Imo" }, { 17, "Jigawa" }, { 18, "Kaduna" }, {19, "Kano" }, { 20, "Katsina" }, {21, "Kebbi" },  { 22, "Kogi" }, { 23, "Kwara"}, { 24, "Lagos" }, { 25, "Nasarawa" }, { 26, "Niger" }, { 27, "Ogun" }, {28, "Ondo" }, { 29, "Osun" }, {30, "Oyo"}, { 31, "Plateau" }, {32, "Rivers" }, {33, "Sokoto" }, {34, "Taraba" }, { 35, "Yobe" }, { 36, "Zamfara"}, { 37, "FCT" } };

        public static Dictionary<int, string> Category = new Dictionary<int, string> { { 0, "Category Unknown" }, { 1, "Automobile and Mechanics" }, { 2, "Entertainment" }, { 3, "Building and Constructions" }, { 4, "Fashion and Beauty" }, { 5, "Furniture and Capentary" }, { 6, "Health and Environment" }, { 7, "Electrical and Electronics" }, { 8, "Testing" } };
    }

}
