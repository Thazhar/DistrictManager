import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { District } from '../Models/district';
import { Seller } from '../Models/seller'
import { HttpErrorHandlerService, HandleError } from './http-error-handler.service';
import { baseUrl } from '../app.component';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  sellerUrl = baseUrl + 'seller';

  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    private httpErrorHandler: HttpErrorHandlerService) {
    this.handleError = httpErrorHandler.createHandleError('SellerService');
  }

  getSellerById(sellerId: number): Observable<Seller> {
    const url = this.sellerUrl + `/${sellerId}`;
    return this.http.get<Seller>(url);
  }

  getAllSellers(): Observable<Seller[]> {
    return this.http.get<Seller[]>(this.sellerUrl)
      .pipe(
        catchError(this.handleError('getAllSellers', []))
      );
  }

  addSeller(seller: Seller): Observable<Seller> {
    return this.http.post<Seller>(this.sellerUrl, seller)
      .pipe(
        catchError(this.handleError('addSeller', seller))
      );
  }

  deleteSeller(sellerId: number): Observable<{}> {
    const url = `${this.sellerUrl}/${sellerId}`;
    return this.http.delete(url)
      .pipe(
        catchError(this.handleError('deleteSeller'))
      );
  }
}
