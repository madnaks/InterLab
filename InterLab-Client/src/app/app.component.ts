import { Component, OnInit } from '@angular/core';
import { StockService } from './services/stock.service';
import { Stock } from './models/stock';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookMarkStockService } from './services/bookmarkstock.service';

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

  constructor(private stockService: StockService, private bookMarkStockService: BookMarkStockService, private _snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.getStocks(this.symbols.map(s => s.symbol));
  }

  public getStocks(symbols: string[]): void {
    this.isWaitingForResponse = true;
    this.stockService.getStocks(symbols).subscribe(
      result => {
        this.stocks = result;
      },
      error => {
        this.isWaitingForResponse = false;
      },
      () => {
        this.isWaitingForResponse = false;
      }
    );
  }

  public symbolsChanging(event: any) {
    this.getStocks((<Array<any>>event.value).map(s => s.symbol));
  }

  public saveStock(stock: Stock) {
    this.isWaitingForResponse = true;

    this.bookMarkStockService.saveBookMarkStock(stock).subscribe( result => {
      this._snackBar.open("Stock enregistré avec succès", undefined, { panelClass : 'success-snack-bar', duration: 1500});
    },
    error => {
      this._snackBar.open("Erreur de sauvegarde du stock", undefined, { panelClass : 'error-snack-bar', duration: 1500});
    },
    () => {
      this.isWaitingForResponse = false;
    });
  }

}
