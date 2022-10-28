import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HungryDay } from '../models/hungryDay';

@Injectable({
  providedIn: 'root'
})
export class HungryService {

  private hungryUrl = 'http://localhost:6072/hungryday';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) { }


 /** GET HungryDayes from the server */
 getHungryDays(): Observable<HungryDay[]> {
  return this.http.get<HungryDay[]>(this.hungryUrl);
}


/** GET HungryDay by id. Will 404 if id not found */
getHungryDay(id: number): Observable<HungryDay> {
  const url = `${this.hungryUrl}/${id}`;
  return this.http.get<HungryDay>(url);
}

resetHungryDay(id: number): Observable<any> {
  const url =`${this.hungryUrl}/${id}`;
  return this.http.delete(url);
}

updateHungryDay(id: number, data: any) : Observable<any>{
  const url =`${this.hungryUrl}/${id}`;
return this.http.post(url, data);
}

}
