using System.Net.Http.Headers;
using InterLab.Application.Interface;
using InterLab.Core.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace InterLab.Application
{
    public class StockDataService: IStockDataService
    {
        private HttpClient HttpClient { get; set; }

        public StockDataService(HttpClient httpClient) {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Stock>> GetStocksBySymbols(IList<string> symbols)
        {
            if (!symbols.Any())
                return new List<Stock>();

            var response = HttpClient.GetAsync(BuildUri(symbols)).Result;

            if (!response.IsSuccessStatusCode)
                return new List<Stock>();

            string results = await response.Content.ReadAsStringAsync();
            StockDataAPI stockDataAPI = JsonConvert.DeserializeObject<StockDataAPI>(results);

            return stockDataAPI.stocks;

            // Use this mocked data in case StockData.Org API usage has reached the limit
            // return MockData().Where(x => symbols.Contains(x.ticker));
        }

        private string BuildUri(IList<string> symbols) {
            string getSymbols = "?symbols=" + symbols.Aggregate((current, next) => current + "%2C" + next);

            HttpClient.BaseAddress = new Uri("https://api.stockdata.org/v1/data/quote");
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string? ApiKey = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ApiKey").Value;

            return getSymbols + "&api_token=" + ApiKey;
        }

        private IList<Stock> MockData()
        {
            return new List<Stock> {
                new Stock()
                {
                    ticker = "TSLA",
                    name = "Tesla Inc",
                    exchange_short = "NASDAQ",
                    exchange_long = "NASDAQ Stock Exchange",
                    mic_code = "XNAS",
                    currency = "USD",
                    price = 168.69,
                    day_high = 169.05,
                    day_low = 163.55,
                    day_open = 163.98,
                    _52_week_high = 315.2,
                    _52_week_low = 101.81,
                    market_cap = 510923374592,
                    previous_close_price = 161.23,
                    previous_close_price_time = new DateTime(),
                    day_change = 4.42,
                    volume = 740607,
                    is_extended_hours_price = false,
                    last_trade_time = new DateTime(2023, 5, 4, 15, 59, 59)
                },
                new Stock()
                {
                    ticker = "AAPL",
                    name = "Apple Inc",
                    exchange_short = "NASDAQ",
                    exchange_long = "NASDAQ Stock Exchange",
                    mic_code = "XNAS",
                    currency = "USD",
                    price = 173.34,
                    day_high = 174.19,
                    day_low = 170.76,
                    day_open = 170.98,
                    _52_week_high = 176.15,
                    _52_week_low = 124.17,
                    market_cap = 2640189063168,
                    previous_close_price = 165.72,
                    previous_close_price_time = new DateTime(2023, 5, 4, 15, 59, 59),
                    day_change = 4.4,
                    volume = 1881504,
                    is_extended_hours_price = false,
                    last_trade_time = new DateTime(2023, 5, 4, 15, 59, 59)
                },
                   new Stock()
                   {
                       ticker = "MSFT",
                       name = "Microsoft Corporation",
                       exchange_short = "NASDAQ",
                       exchange_long = "NASDAQ Stock Exchange",
                       mic_code = "XNAS",
                       currency = "USD",
                       price = 309.56,
                       day_high = 309.77,
                       day_low = 304.31,
                       day_open = 305.84,
                       _52_week_high = 309.18,
                       _52_week_low = 213.43,
                       market_cap = 2278407536640,
                       previous_close_price = 305.5,
                       previous_close_price_time = new DateTime(2023, 5, 4, 15, 59, 59),
                       day_change = 1.31,
                       volume = 574728,
                       is_extended_hours_price = false,
                       last_trade_time = new DateTime(2023, 5, 4, 15, 59, 59)
                   }
            };
        }
    }
}
