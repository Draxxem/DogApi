using DogApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DogApi.Controller
{
    public class ConfigManager
    {
        public DogApiConfig Config()
        {
            var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("AppSettings.json").Build();

            var section = config.GetSection(nameof(DogApiConfig));
            var dogApiConfig = section.Get<DogApiConfig>();

            return dogApiConfig;
        }
    }
}
