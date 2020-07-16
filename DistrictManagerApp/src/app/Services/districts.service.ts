import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { District } from '../Models/district';
import { HttpErrorHandlerService, HandleError } from './http-error-handler.service';
import { baseUrl } from '../app.component';


@Injectable({
  providedIn: 'root'
})

export class DistrictsService {
  districtUrl = baseUrl + 'districts';// URL for web api
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    private httpErrorHandler: HttpErrorHandlerService){
    this.handleError = httpErrorHandler.createHandleError('DistrictService');
    }


  getAllDistricts (): Observable<District[]> {
    return this.http.get<District[]>(this.districtUrl)
      .pipe(
        catchError(this.handleError('getAllDistricts', []))
      );
  }

  getDistrictById (districtId: number): Observable<District> {
    const url = this.districtUrl + `/${districtId}`;
    return this.http.get<District>(url);
  }

  deleteDistrict(districtId: number): Observable<{}> {
    const url = `${this.districtUrl}/${districtId}`;
    return this.http.delete(url)
      .pipe(
        catchError(this.handleError('deleteDistrict'))
      );
  }

  addDistrict (district: District): Observable<District> {
    return this.http.post<District>(this.districtUrl, district)
      .pipe(
        catchError(this.handleError('addDistrict', district))
      );
  }
}
