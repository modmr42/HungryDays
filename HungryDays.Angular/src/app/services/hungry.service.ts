import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HungryDay } from '../models/hungryDay';

@Injectable({
  providedIn: 'root'
})
export class HungryService {

  private hungryUrl = 'https://6318a165ece2736550cfb574.mockapi.io/api/v1/hungrydays/';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) { }


 /** GET HungryDayes from the server */
 getHungryDays(): Observable<HungryDay[]> {
  return this.http.get<HungryDay[]>(this.hungryUrl)
    .pipe(
      tap(_ => this.log('fetched HungryDayes')),
      catchError(this.handleError<HungryDay[]>('getHungryDayes', []))
    );
}


/** GET HungryDay by id. Will 404 if id not found */
getHungryDay(id: number): Observable<HungryDay> {
  const url = `${this.hungryUrl}/${id}`;
  return this.http.get<HungryDay>(url).pipe(
    tap(_ => this.log(`fetched HungryDay id=${id}`)),
    catchError(this.handleError<HungryDay>(`getHungryDay id=${id}`))
  );
}

private handleError<T>(operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // TODO: better job of transforming error for user consumption
    this.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}

/** Log a HeroService message with the MessageService */
private log(message: string) {
  
}
}
