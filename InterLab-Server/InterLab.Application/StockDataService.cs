using System.Net.Http.Headers;
using InterLab.Application.Interface;
using InterLab.Core.Models;
using Newtonsoft.Json;

namespace InterLab.Application
{
    public class StockDataService: IStockDataService
    {
        private HttpClient HttpClient { get; set; }
        
        public StockDataService(HttpClient httpClient) {
            HttpClient = httpClient;
        }
        
        public async Task<IEnumerable<Stock>> GetStocks()
        {
            StockDataAPI stockDataAPI = new StockDataAPI();

            HttpClient.BaseAddress = new Uri("https://api.stockdata.org/v1/data/quote");
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = HttpClient.GetAsync("?symbols=AAPL%2CTSLA%2CMSFT&api_token=02cJE0Tb440ffeid8B0FwdLptsFnPBmcGZekhhp4").Result;

            if (response.IsSuccessStatusCode)
            {
                string results = await response.Content.ReadAsStringAsync();

                stockDataAPI = JsonConvert.DeserializeObject<StockDataAPI>(results);
            }
            
            return stockDataAPI.stocks;
        }
    }
}
