using RestSharp;
using System.Threading.Tasks;

namespace DogApi.Controller
{
    class DogController
    {
        public async Task<IRestResponse> GetDogBreeds(string requestUrl)
        {
            var client = new RestClient(requestUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse response = await Task.FromResult(client.Execute(request));
            return response;
        }
    }
}
