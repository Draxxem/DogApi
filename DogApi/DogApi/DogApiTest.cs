using DogApi.Controller;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace DogApi
{
     class DogApiTest : Models.Model
    {
        DogController dog = new DogController();

        [Test]
        public void VerifyRetrieverIsWithinList()
        {        
            var response = dog.GetDogBreeds("https://dog.ceo/api/breeds/list/all");
            string json = response.Result.Content;
            Root dogBreeds = JsonConvert.DeserializeObject<Root>(json);
            string breedList = JsonConvert.SerializeObject(dogBreeds, Formatting.Indented);
            Console.WriteLine(breedList);
            Assert.IsTrue(breedList.Contains("retriever"));     
        }

        [Test]
        public void ReturnRetrieverSubBreeds()
        {
            var response = dog.GetDogBreeds("https://dog.ceo/api/breeds/list/all");
            string json = response.Result.Content;
            Root dogBreeds = JsonConvert.DeserializeObject<Root>(json);
            string subBreed = JsonConvert.SerializeObject(dogBreeds.message.retriever, Formatting.Indented);            
            Console.WriteLine(subBreed);
            Assert.That(subBreed.Contains("golden"));
        }

        [Test]
        public void ProduceRandomImageLinkForSubBreed()
        {
            var response = dog.GetDogBreeds("https://dog.ceo/api/breed/retriever/golden/images/random");
            string imageLink = response.Result.Content;
            string expression = @"\\";
            Match m = Regex.Match(imageLink,expression);
            string randomImage = imageLink.Replace(m.ToString(),"");
            Console.WriteLine(randomImage);
            Assert.That(randomImage.Contains(".jpg"));
        }
    }
}