import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookMarkStockService } from '../services/bookmarkstock.service';
import { Stock } from '../models/stock';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-bookmark-stock',
  templateUrl: './bookmark-stock.component.html',
  styleUrls: ['./bookmark-stock.component.scss']
})
export class BookmarkStockComponent {

  public bookmarkStockForm: FormGroup;
  public symbols = [
    { symbol: "AAPL", name: "Apple" },
    { symbol: "MSFT", name: "Microsoft" },
    { symbol: "TSLA", name: "Tesla" }
  ];
  stocks: Stock[] = [];
  displayedColumns: string[] = ['ticker', 'name', 'exchange_short', 'price'];
  isWaitingForResponse: boolean = false;

  constructor(private formBuilder: FormBuilder, private bookMarkStockService: BookMarkStockService, public datepipe: DatePipe) {
    this.bookmarkStockForm = this.formBuilder.group({
      symbol: ['', [Validators.required]],
      date: ['', [Validators.required]]
    });
  }

  public getBookmarkStocks(x: any) {
    let symbol = x.value.symbol;
    let date = this.datepipe.transform(new Date(x.value.date), 'yyyy-MM-dd');
    this.isWaitingForResponse = true;
    this.bookMarkStockService.getBookmarkStocks(symbol, date).subscribe({
      next: result => this.stocks = result,
      error: () => this.isWaitingForResponse = false,
      complete: () => this.isWaitingForResponse = false
    });
  }
}
