using AllBackgroundStuff;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(5);

            var result = httpClient.GetAsync("https://localhost:5001/api/ModelA/10");

            result.Wait();

            if (!result.IsCompletedSuccessfully)
                Console.WriteLine("Not completed succesfully");

            var outputString = result.Result.Content.ReadAsStringAsync().Result;

            var modelAReadDTO = JsonConvert.DeserializeObject<ModelAReadDTO>(outputString);
        }
    }
}
