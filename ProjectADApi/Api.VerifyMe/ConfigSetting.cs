using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Api.VerifyMe
{
    class ConfigSetting
    {
        private string _baseUrl;
        string _bvn;
        string _dl;
        string _nin;
        string address;

        public ConfigSetting()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ApiDbConnection").GetSection("DefaultConnection").Value;
            var appSetting = root.GetSection("ApplicationSettings");
        }
       public string BaseUrl { get; set; }
        public string BankVerificationNumberEndpoint { get; set; }
        public string DriverLicenseEndpoint { get; set; }
        public string NationalIdentiyNumberEndpoint { get; set; }
        public string AddressEndpoint { get; set; }
    }
}
