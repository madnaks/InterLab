import { Component } from '@angular/core';
import { StockService } from '../core/services/stock.service';
import { Stock } from '../core/models/stock';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookMarkStockService } from '../core/services/bookmarkstock.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
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
    this.stockService.getStocks(symbols).subscribe({
      next: result => this.stocks = result,
      error: () => this.isWaitingForResponse = false,
      complete: () => this.isWaitingForResponse = false
    });
  }

  public symbolsChanging(event: any) {
    this.getStocks((<Array<any>>event.value).map(s => s.symbol));
  }

  public saveStock(stock: Stock) {
    this.isWaitingForResponse = true;
    this.bookMarkStockService.saveBookMarkStock(stock).subscribe({
      next: () => this._snackBar.open("Stock enregistré avec succès", undefined, { panelClass: 'success-snack-bar', duration: 1500 }),
      error: error => { 
        this._snackBar.open("Erreur de sauvegarde du stock", undefined, { panelClass: 'error-snack-bar', duration: 1500 });
        this.isWaitingForResponse = false;
      },
      complete: () => this.isWaitingForResponse = false
    });
  }
}
