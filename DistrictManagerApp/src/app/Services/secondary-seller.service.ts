import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { District } from '../Models/district';
import { Seller } from '../Models/seller'
import { HttpErrorHandlerService, HandleError } from './http-error-handler.service';
import { baseUrl } from '../app.component';
import {SecondarySeller} from '../Models/secondarySeller';

@Injectable({
  providedIn: 'root'
})
export class SecondarySellerService {
  secondarySellerUrl = baseUrl + 'secondaryseller';
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    private httpErrorHandler: HttpErrorHandlerService) {
    this.handleError = httpErrorHandler.createHandleError('SecondarySellerService');
  }

  getSecondarySellersByDistrictId(districtId: number): Observable<SecondarySeller[]> {
    const url = this.secondarySellerUrl + `/${districtId}`;
    return this.http.get<SecondarySeller[]>(url)
      .pipe(
        catchError(this.handleError('getSecondarySellersByDistrictId', []))
      );
  }

  deleteSecondarySeller(sellerId: number, districtId: number) {
    const url = this.secondarySellerUrl + `/${sellerId}/${districtId}`;
    return this.http.delete(url).pipe(
      catchError(this.handleError('deleteSecondarySeller'))
    );
  }

  addSecondarySeller(secondarySeller: SecondarySeller): Observable<SecondarySeller> {
    return this.http.post<SecondarySeller>(this.secondarySellerUrl, secondarySeller)
      .pipe(
        catchError(this.handleError('addSecondarySeller', secondarySeller))
      );
  }
}
