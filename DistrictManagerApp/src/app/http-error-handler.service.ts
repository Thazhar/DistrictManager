import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';

// Type alias of the handleError function returned by HttpErrorHandlerService.createHandleError
export type HandleError =
  <T> (operation?: string, result?: T) => (error: HttpErrorResponse) => Observable<T>;

@Injectable({
  providedIn: 'root'
})

// Handles HttpClient errors
export class HttpErrorHandlerService {
  constructor() { }

  //Creates a curried handleError function that contains the right service name
  createHandleError = (serviceName = '') => <T>
    (operation = 'operation', result = {} as T) => this.handleError(serviceName, operation, result)

  // Function that handles Http operation failures, ensures app continues in case of errors.
  private handleError<T> (serviceName = '', operations = 'operation', result = {} as T) {
    return (error: HttpErrorResponse): Observable<T> => {
      // Should send error to remote logging infrastructure, just logs to console instead.
      console.error(error);

      //TODO: Is this needed?
      //const message = (error.error instanceof ErrorEvent) ?
      //  error.error.message : `server returned code ${error.status} with body "${error.error}"`;

      return of( result );
    };
  }
}
