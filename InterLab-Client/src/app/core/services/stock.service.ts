import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stock } from '../models/stock';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  readonly rootURL = 'https://localhost:44303/Stock/';

  constructor(private http: HttpClient) { }

  getStocks(symbols: string[]): Observable<Stock[]> {
    return this.http.post<Stock[]>(this.rootURL + 'GetStocksBySymbols', symbols);
  }
}
