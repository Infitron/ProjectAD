using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Api.Database
{
    class AppConfig
    {
        public readonly string _connectionString = string.Empty;
        public AppConfig()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ApiDbConnection").GetSection("DefaultConnection").Value;
            var appSetting = root.GetSection("ApplicationSettings");
        }
        public string ConnectionString
        {
            get => _connectionString;
        }
    

    }
}
