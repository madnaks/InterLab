export class Stock {
    ticker: string;
    name: string;
    exchange_short: string;
    exchange_long: string;
    mic_code: string;
    currency: string;
    price: number;
    day_high: number;
    day_low: number;
    day_open: number;
    _52_week_high: number;
    _52_week_low: number;
    market_cap: number;
    previous_close_price: number;
    previous_close_price_time: Date;
    day_change: number;
    volume: number;
    is_extended_hours_price: boolean;
    last_trade_time: Date;

    constructor() {
        this.ticker = '';
        this.name = '';
        this.exchange_short = '';
        this.exchange_long = '';
        this.mic_code = '';
        this.currency = '';
        this.price = 0;
        this.day_high = 0;
        this.day_low = 0;
        this.day_open = 0;
        this._52_week_high = 0;
        this._52_week_low = 0;
        this.market_cap = 0;
        this.previous_close_price = 0;
        this.previous_close_price_time = new Date();
        this.day_change = 0;
        this.volume = 0;
        this.is_extended_hours_price = false;
        this.last_trade_time = new Date();

    }
}