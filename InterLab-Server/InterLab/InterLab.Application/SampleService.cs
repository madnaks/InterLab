using System.Net.Http.Headers;

namespace InterLab.Application
{
    public class SampleService: ISampleService
    {
        private HttpClient HttpClient { get; set; }
        
        public SampleService(HttpClient httpClient) {
            HttpClient = httpClient;
        }
        
        public async Task<string> GetNews()
        {
            var results = string.Empty;
            List<string> list = new List<string>(); 
            HttpClient.BaseAddress = new Uri("https://api.goperigon.com/v1/all");

            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = HttpClient.GetAsync("?apiKey=bd4007bd-caf0-4697-a2ea-d47fb9f28066").Result;
            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsStringAsync();
            }

            return results;
        }
    }

    public interface ISampleService
    {
        Task<string> GetNews();
    }
}
