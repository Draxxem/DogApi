using DogApi.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Assert = NUnit.Framework.Assert;

namespace DogApi
{
    [TestClass]
     class DogApiTest : Models.DogBreed
    {
        HttpClientHelper dog = new HttpClientHelper();
        ConfigManager conf = new ConfigManager();

        [Test]
        public void VerifyRetrieverIsWithinList()
        {   
            var response = dog.GetRequest(conf.Config().AllBreedsUrl);
            string json = response.Result.Content;
            BreedDetailsRoot dogBreeds = JsonConvert.DeserializeObject<BreedDetailsRoot>(json);
            string breedList = JsonConvert.SerializeObject(dogBreeds, Formatting.Indented);
            Assert.IsTrue(breedList.Contains("retriever"));     
        }

        [Test]
        public void ReturnRetrieverSubBreeds()
        {
            var response = dog.GetRequest(conf.Config().AllBreedsUrl);
            string json = response.Result.Content;
            BreedDetailsRoot dogBreeds = JsonConvert.DeserializeObject<BreedDetailsRoot>(json);
            string subBreed = JsonConvert.SerializeObject(dogBreeds.message.retriever, Formatting.Indented);            
            Assert.That(subBreed.Contains("golden"));
        }

        [Test]
        public void ProduceRandomImageLinkForSubBreed()
        {
            var response = dog.GetRequest(conf.Config().RandomBreedsUrl);
            string imageLink = response.Result.Content;
            string expression = @"\\";
            Match m = Regex.Match(imageLink,expression);
            string randomImage = imageLink.Replace(m.ToString(),"");
            Assert.That(randomImage.Contains(".jpg"));
        }
    }
}