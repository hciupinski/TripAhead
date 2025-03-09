import {inject, Injectable} from '@angular/core';
import {catchError, map, Observable, of} from "rxjs";
import {TripResponse, TripsResponse} from "../../../types/trip";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import Keycloak from "keycloak-js";

@Injectable({
  providedIn: 'root'
})
export class TripsApiService {
  private readonly apiUrl = '/trips.api'
  constructor(private http: HttpClient) {}

  getTrips(): Observable<TripsResponse> {
    return this.http.get<TripsResponse>(this.apiUrl + '/trips/manage').pipe(
      catchError((error) => {
        console.error('Error fetching trips', error);
        return of(error);
      })
    );
  }

  getTrip(tripId: string): Observable<TripResponse> {
    return this.http.get<TripResponse>(this.apiUrl + `/trips/manage/${tripId}`).pipe(
      catchError((error) => {
        console.error('Error fetching trips', error);
        return of(error);
      })
    );
  }

  createTrip(request: string): Observable<string> {
    return this.http.post<TripResponse>(this.apiUrl + `/trips/manage/`, request).pipe(
      catchError((error) => {
        console.error('Error fetching trips', error);
        return of(error);
      })
    );
  }

  updateTrip(request: string): Observable<string> {
    return this.http.put<TripResponse>(this.apiUrl + `/trips/manage/`, request).pipe(
      catchError((error) => {
        console.error('Error fetching trips', error);
        return of(error);
      })
    );
  }
}
