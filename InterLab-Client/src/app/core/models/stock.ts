export class Stock {
  createdDate: Date;
  ticker: string;
  name: string;
  exchange_short: string;
  currency: string;
  price: number;
  previous_close_price: number;
  previous_close_price_time: Date;
  last_trade_time: Date;
  price_diff: number;
  price_diff_percentage: number;

  constructor() {
    this.createdDate = new Date();
    this.ticker = '';
    this.name = '';
    this.exchange_short = '';
    this.currency = '';
    this.price = 0;
    this.previous_close_price = 0;
    this.previous_close_price_time = new Date();
    this.last_trade_time = new Date();
    this.price_diff = 0;
    this.price_diff_percentage = 0;
  }
}
