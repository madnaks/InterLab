import { Component, OnInit } from '@angular/core';
import { StockService } from './services/stock.service';
import { Stock } from './models/stock';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  stocks: Stock[] = [];
  stocksPriceDiff: number[] = [];

  constructor(private stockService: StockService) {
  }

  ngOnInit(): void {
    this.stockService.getStocks().subscribe(
      result => {
        this.stocks = result;
        for (let index = 0; index < this.stocks.length; index++) {
          this.stocksPriceDiff[index] = this.calculPriceDifference(this.stocks[index].price, this.stocks[index].previous_close_price);
        }
      }
    );

    // this.stocks = [
    //   {
    //     "ticker": "TSLA",
    //     "name": "Tesla Inc",
    //     "exchange_short": "NASDAQ",
    //     "exchange_long": "NASDAQ Stock Exchange",
    //     "mic_code": "XNAS",
    //     "currency": "USD",
    //     "price": 168.69,
    //     "day_high": 169.05,
    //     "day_low": 163.55,
    //     "day_open": 163.98,
    //     "_52_week_high": 315.2,
    //     "_52_week_low": 101.81,
    //     "market_cap": 510923374592,
    //     "previous_close_price": 161.23,
    //     "previous_close_price_time": new Date(2023,5,4,15,59,59),
    //     "day_change": 4.42,
    //     "volume": 740607,
    //     "is_extended_hours_price": false,
    //     "last_trade_time": new Date(2023,5,4,15,59,59)
    //   },
    //   {
    //     "ticker": "AAPL",
    //     "name": "Apple Inc",
    //     "exchange_short": "NASDAQ",
    //     "exchange_long": "NASDAQ Stock Exchange",
    //     "mic_code": "XNAS",
    //     "currency": "USD",
    //     "price": 173.34,
    //     "day_high": 174.19,
    //     "day_low": 170.76,
    //     "day_open": 170.98,
    //     "_52_week_high": 176.15,
    //     "_52_week_low": 124.17,
    //     "market_cap": 2640189063168,
    //     "previous_close_price": 165.72,
    //     "previous_close_price_time": new Date(2023,5,4,15,59,59),
    //     "day_change": 4.4,
    //     "volume": 1881504,
    //     "is_extended_hours_price": false,
    //     "last_trade_time": new Date(2023,5,4,15,59,59)
    //   },
    //   {
    //     "ticker": "MSFT",
    //     "name": "Microsoft Corporation",
    //     "exchange_short": "NASDAQ",
    //     "exchange_long": "NASDAQ Stock Exchange",
    //     "mic_code": "XNAS",
    //     "currency": "USD",
    //     "price": 309.56,
    //     "day_high": 309.77,
    //     "day_low": 304.31,
    //     "day_open": 305.84,
    //     "_52_week_high": 309.18,
    //     "_52_week_low": 213.43,
    //     "market_cap": 2278407536640,
    //     "previous_close_price": 305.5,
    //     "previous_close_price_time": new Date(2023,5,4,15,59,59),
    //     "day_change": 1.31,
    //     "volume": 574728,
    //     "is_extended_hours_price": false,
    //     "last_trade_time": new Date(2023,5,4,15,59,59)
    //   }
    // ];

    // for (let index = 0; index < this.stocks.length; index++) {
    //   this.stocksPriceDiff[index] = this.calculPriceDifference(this.stocks[index].price, this.stocks[index].previous_close_price);
    // }
  }

  public calculPriceDifference(price: number, previous_close_price: number): number {
    let result = ((price - previous_close_price) / previous_close_price) * 100;
    return result;
  }
}
