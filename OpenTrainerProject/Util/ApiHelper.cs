using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OpenTrainerProject.Util
{
    class ApiHelper
    {
        private readonly Uri baseUri = new Uri("http://localhost:8000/");
        private readonly HttpClient client;

        public ApiHelper()
        {
            client = new HttpClient
            {
                BaseAddress = baseUri
            };
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public string Fetch(string url) 
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return "[Error] " + response.StatusCode + " : Message - " + response.ReasonPhrase;
                }
            }
            catch (Exception)
            {
                return "[Error] Could not connect to server! Please Check your internet connection and restart the program.";
            }
        }
    }
}
