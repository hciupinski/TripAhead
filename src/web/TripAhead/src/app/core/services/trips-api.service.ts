import { Injectable } from '@angular/core';
import {catchError, Observable, of} from "rxjs";
import {Trips} from "../../../types/trip";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TripsApiService {
  private readonly apiUrl = '/trips.api/'
  constructor(private http: HttpClient) {}

  getTrips(): Observable<Trips> {
    return this.http.get<Trips>(this.apiUrl + '/trips/manage').pipe(
      catchError((error) => {
        console.error('Error fetching trips', error);
        return of(error);
      })
    );
  }
}
