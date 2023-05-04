using Newtonsoft.Json;

namespace InterLab.Core.Models
{
    public class StockDataAPI
    {
        public Meta? meta { get; set; }

        [JsonProperty("data")]
        public List<Stock>? stocks { get; set; }
    }
}
