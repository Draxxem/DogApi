using DogApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DogApi.Controller
{
    public class ConfigManager
    {
        public DogApiConfig Config()
        {
            var path = Path.GetFullPath(@"..\..\..\");
            var config = new ConfigurationBuilder().SetBasePath(path)
          .AddJsonFile("AppSettings.json").Build();

            var section = config.GetSection(nameof(DogApiConfig));
            var dogApiConfig = section.Get<DogApiConfig>();

            return dogApiConfig;
        }
    }
}
