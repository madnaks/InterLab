﻿namespace InterLab.Core.Models
{
    public class BookMarkStock
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Ticker { get; set; }
        public string? Name { get; set; }
        public string? Exchange_short { get; set; }
        public string? Currency { get; set; }
        public double Price { get; set; }
        public double Previous_close_price { get; set; }
        public DateTime Last_trade_time { get; set; }
        public double Price_diff { get; set; }
        public double Price_diff_percentage { get; set; }
    }
}
