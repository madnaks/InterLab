import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stock } from '../models/stock';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookMarkStockService {

  constructor(private http: HttpClient) { }

  saveBookMarkStock(stock: Stock): Observable<boolean> {
    return this.http.post<boolean>(environment.bookMarkStockUrl + 'SaveBookMarkStock', stock);
  }

  getBookmarkStocks(symbol: string, date: string | null): Observable<Stock[]> {
    return this.http.get<Stock[]>(environment.bookMarkStockUrl + 'GetBookmarkStocks/'+ symbol + '/' + date);
  }
}
