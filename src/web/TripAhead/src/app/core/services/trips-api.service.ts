import {inject, Injectable} from '@angular/core';
import {catchError, map, Observable, of} from "rxjs";
import {TripsResponse} from "../../../types/trip";
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
}
