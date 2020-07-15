import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { District } from './district';
import { HttpErrorHandlerService, HandleError } from '../http-error-handler.service';

const HttpOptions = {
  headers: new HttpHeaders({
    'Content-type': 'application/json',
    Authorization: 'my-auth-token'   // Does this need quotes?
  })
};

@Injectable({
  providedIn: 'root'
})

export class DistrictsService {
  districtUrl = 'https://localhost:44328/api/districts'; // URL for web api
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

  deleteDistrict(districtId: number): Observable<{}> {
    const url = `${this.districtUrl}/${districtId}`;
    return this.http.delete(url)
      .pipe(
        catchError(this.handleError('deleteHero'))
      );
  };
}
