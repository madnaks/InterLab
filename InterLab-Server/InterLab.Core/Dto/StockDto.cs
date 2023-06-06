namespace InterLab.Core.Dto
{
    public class StockDto
    {
        public DateTime? CreatedDate { get; set; }
        public string? Ticker { get; set; }
        public string? Name { get; set; }
        public string? Exchange_short { get; set; }
        public string? Currency { get; set; }
        public double Price { get; set; }
        public double Previous_close_price { get; set; }
        public DateTime Previous_close_price_time { get; set; }
        public DateTime Last_trade_time { get; set; }
        public double Price_diff { get; set; }
        public double Price_diff_percentage { get; set; }
    }
}
