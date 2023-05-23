import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stock } from '../models/stock';

@Injectable({
  providedIn: 'root'
})
export class BookMarkStockService {

  readonly rootURL = 'https://localhost:44303/BookMarkStock/';

  constructor(private http: HttpClient) { }

  saveBookMarkStock(stock: Stock): Observable<boolean> {
    return this.http.post<boolean>(this.rootURL + 'SaveBookMarkStock', stock);
  }

  getBookmarkStocks(symbol: string, date: string | null): Observable<Stock[]> {
    return this.http.get<Stock[]>(this.rootURL + 'GetBookmarkStocks/'+ symbol + '/' + date);
  }
}
