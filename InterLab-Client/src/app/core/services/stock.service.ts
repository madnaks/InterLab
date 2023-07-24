import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stock } from '../models/stock';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http: HttpClient) { }

  getStocks(symbols: string[]): Observable<Stock[]> {
    return this.http.post<Stock[]>(environment.stockUrl + 'GetStocksBySymbols', symbols);
  }
}
