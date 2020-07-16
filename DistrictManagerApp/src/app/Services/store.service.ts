import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { HttpErrorHandlerService, HandleError } from './http-error-handler.service';
import { baseUrl } from '../app.component';
import { Store } from '../Models/store';
import {Seller} from '../Models/seller';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  storeUrl = baseUrl + 'store';
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    private httpErrorHandler: HttpErrorHandlerService) {
    this.handleError = httpErrorHandler.createHandleError('StoreService');
  }

    getAllStores(): Observable<Store[]> {
      return this.http.get<Store[]>(this.storeUrl)
        .pipe(
          catchError(this.handleError('getAllStores', []))
        );
    }

  addStore(store: Store): Observable<Store> {
    return this.http.post<Store>(this.storeUrl, store)
      .pipe(
        catchError(this.handleError('addStore', store))
      );
  }
}
