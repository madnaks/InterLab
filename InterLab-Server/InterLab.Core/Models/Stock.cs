using Newtonsoft.Json;

namespace InterLab.Core.Models
{
    public class Stock
    {
        public string? Ticker { get; set; }
        public string? Name { get; set; }
        public string? Exchange_short { get; set; }
        public string? Exchange_long { get; set; }
        public string? Mic_code { get; set; }
        public string? Currency { get; set; }
        public double Price { get; set; }
        public double Day_high { get; set; }
        public double Day_low { get; set; }
        public double Day_open { get; set; }

        [JsonProperty("52_week_high")]
        public double _52_week_high { get; set; }

        [JsonProperty("52_week_low")]
        public double _52_week_low { get; set; }
        public long? Market_cap { get; set; }
        public double Previous_close_price { get; set; }
        public DateTime Previous_close_price_time { get; set; }
        public double Day_change { get; set; }
        public int Volume { get; set; }
        public bool Is_extended_hours_price { get; set; }
        public DateTime Last_trade_time { get; set; }
        public double Price_diff => Price - Previous_close_price;
        public double Price_diff_percentage => ((Price - Previous_close_price) / Previous_close_price) * 100;
    }
}
