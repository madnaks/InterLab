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
  isWaitingForResponse: boolean = false;

  symbols = [
    { symbol: "AAPL", name: "Apple" },
    { symbol: "MSFT", name: "Microsoft" },
    { symbol: "TSLA", name: "Tesla" }
  ];

  constructor(private stockService: StockService) {
  }

  ngOnInit(): void {
    this.getStocks(this.symbols.map(s => s.symbol));
  }

  public getStocks(symbols: string[]): void {
    this.isWaitingForResponse = true;
    this.stockService.getStocks(symbols).subscribe(
      result => {
        this.stocks = result;
        this.isWaitingForResponse = false;
      }
    );
  }

  public symbolsChanging(event: any) {
    this.getStocks((<Array<any>>event.value).map(s => s.symbol));
  }
}
