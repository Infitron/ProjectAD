using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Api.VerifyMe
{
   public class VerifyMeConfig 
    {
        private string _baseUrl;
        string _bvn;
        string _dl;
        string _nin;
        string _address;
        string _apikey;

        public VerifyMeConfig()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _baseUrl = root.GetSection("VerifyMe").GetSection("BaseUrl").Value;
            _bvn = root.GetSection("VerifyMe").GetSection("BankVerificationNumberEndpoint").Value;
            _dl = root.GetSection("VerifyMe").GetSection("NationalIdentiyNumberEndpoint").Value;
            _nin = root.GetSection("VerifyMe").GetSection("AddressEndpoint").Value;
            _apikey = root.GetSection("VerifyMe").GetSection("ApiKey").Value;
            var appSetting = root.GetSection("ApplicationSettings");
        }

        public string BaseUrl => _baseUrl;
        public string BankVerificationNumberEndpoint => _bvn;
        public string DriverLicenseEndpoint => _dl;
        public string NationalIdentiyNumberEndpoint => _nin;
        public string AddressEndpoint => _address;

        public string ApiKey => _apikey;
        
    }
}
