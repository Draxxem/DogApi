using DogApi.Controller;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace DogApi
{
     class DogApiTest : Models.DogBreed
    {
        HttpClientHelper dog = new HttpClientHelper();

        [Test]
        public void VerifyRetrieverIsWithinList()
        {        
            var response = dog.GetRequest("https://dog.ceo/api/breeds/list/all");
            string json = response.Result.Content;
            BreedDetailsRoot dogBreeds = JsonConvert.DeserializeObject<BreedDetailsRoot>(json);
            string breedList = JsonConvert.SerializeObject(dogBreeds, Formatting.Indented);
            Assert.IsTrue(breedList.Contains("retriever"));     
        }

        [Test]
        public void ReturnRetrieverSubBreeds()
        {
            var response = dog.GetRequest("https://dog.ceo/api/breeds/list/all");
            string json = response.Result.Content;
            BreedDetailsRoot dogBreeds = JsonConvert.DeserializeObject<BreedDetailsRoot>(json);
            string subBreed = JsonConvert.SerializeObject(dogBreeds.message.retriever, Formatting.Indented);            
            Assert.That(subBreed.Contains("golden"));
        }

        [Test]
        public void ProduceRandomImageLinkForSubBreed()
        {
            var response = dog.GetRequest("https://dog.ceo/api/breed/retriever/golden/images/random");
            string imageLink = response.Result.Content;
            string expression = @"\\";
            Match m = Regex.Match(imageLink,expression);
            string randomImage = imageLink.Replace(m.ToString(),"");
            Assert.That(randomImage.Contains(".jpg"));
        }
    }
}