using System.Net.Http.Headers;
using InterLab.Application.Interface;
using InterLab.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using InterLab.Core.Dto;
using AutoMapper;

namespace InterLab.Application
{
    public class StockService: IStockService
    {
        private HttpClient HttpClient { get; set; }
        private readonly ILogger<StockService> _logger;
        public readonly IMapper _mapper;

        public StockService(HttpClient httpClient, ILogger<StockService> logger, IMapper mapper) {
            HttpClient = httpClient;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDto>> GetStocksBySymbols(IList<string> symbols)
        {
            try
            {
                if (!symbols.Any())
                    return new List<StockDto>();

                //var response = HttpClient.GetAsync(BuildUri(symbols)).Result;

                //if (!response.IsSuccessStatusCode)
                //    return new List<StockDto>();

                //string results = await response.Content.ReadAsStringAsync();
                //StockDataAPI stockDataAPI = JsonConvert.DeserializeObject<StockDataAPI>(results);

                //return _mapper.Map<List<StockDto>>(stockDataAPI.stocks);

                // Use this mocked data in case StockData.Org API usage has reached the limit
                return _mapper.Map<List<StockDto>>(MockData().Where(x => symbols.Contains(x.Ticker)));
            }
            catch (Exception ex)
            {
                _logger.LogError("Stock Service error {ex}", ex);
                throw new Exception("Exception", ex);
            }
        }

        private string BuildUri(IList<string> symbols) {
            string getSymbols = "?symbols=" + symbols.Aggregate((current, next) => current + "%2C" + next);

            HttpClient.BaseAddress = new Uri("https://api.stockdata.org/v1/data/quote");
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string? ApiKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiKey").Value;

            return getSymbols + "&api_token=" + ApiKey;
        }

        private IList<Stock> MockData()
        {
            return new List<Stock> {
                new Stock()
                {
                    Ticker = "TSLA",
                    Name = "Tesla Inc",
                    Exchange_short = "NASDAQ",
                    Exchange_long = "NASDAQ Stock Exchange",
                    Mic_code = "XNAS",
                    Currency = "USD",
                    Price = 168.69,
                    Day_high = 169.05,
                    Day_low = 163.55,
                    Day_open = 163.98,
                    _52_week_high = 315.2,
                    _52_week_low = 101.81,
                    Market_cap = 510923374592,
                    Previous_close_price = 161.23,
                    Previous_close_price_time = new DateTime(),
                    Day_change = 4.42,
                    Volume = 740607,
                    Is_extended_hours_price = false,
                    Last_trade_time = new DateTime(2023, 5, 4, 15, 59, 59)
                },
                new Stock()
                {
                    Ticker = "AAPL",
                    Name = "Apple Inc",
                    Exchange_short = "NASDAQ",
                    Exchange_long = "NASDAQ Stock Exchange",
                    Mic_code = "XNAS",
                    Currency = "USD",
                    Price = 173.34,
                    Day_high = 174.19,
                    Day_low = 170.76,
                    Day_open = 170.98,
                    _52_week_high = 176.15,
                    _52_week_low = 124.17,
                    Market_cap = 2640189063168,
                    Previous_close_price = 165.72,
                    Previous_close_price_time = new DateTime(2023, 5, 4, 15, 59, 59),
                    Day_change = 4.4,
                    Volume = 1881504,
                    Is_extended_hours_price = false,
                    Last_trade_time = new DateTime(2023, 5, 4, 15, 59, 59)
                },
                new Stock()
                {
                    Ticker = "MSFT",
                    Name = "Microsoft Corporation",
                    Exchange_short = "NASDAQ",
                    Exchange_long = "NASDAQ Stock Exchange",
                    Mic_code = "XNAS",
                    Currency = "USD",
                    Price = 309.56,
                    Day_high = 309.77,
                    Day_low = 304.31,
                    Day_open = 305.84,
                    _52_week_high = 309.18,
                    _52_week_low = 213.43,
                    Market_cap = 2278407536640,
                    Previous_close_price = 305.5,
                    Previous_close_price_time = new DateTime(2023, 5, 4, 15, 59, 59),
                    Day_change = 1.31,
                    Volume = 574728,
                    Is_extended_hours_price = false,
                    Last_trade_time = new DateTime(2023, 5, 4, 15, 59, 59)
                }
            };
        }
    }
}
