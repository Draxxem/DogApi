using System;
using System.Collections.Generic;
using System.Text;

namespace DogApi.Models
{
    public class DogApiConfig
    {
        public bool IsEnabled { get; set; }
        public string AllBreedsUrl { get; set; }
        public string RandomBreedsUrl { get; set; }
        public string Timeout { get; set; }
    }
}
