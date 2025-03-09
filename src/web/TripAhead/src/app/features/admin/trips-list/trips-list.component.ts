import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {Trip, TripState} from "../../../../types/trip";
import {Store} from "@ngrx/store";
import {TripsState} from "../../../core/store/trips/trips.reducer";
import {selectAllTrips, selectTripsError, selectTripsLoading} from "../../../core/store/trips/trips.selector";
import {CommonModule} from "@angular/common";
import {loadTrips} from "../../../core/store/trips/trips.actions";
import {Router} from "@angular/router";
import {TableModule} from "primeng/table";
import {ButtonModule} from "primeng/button";
import {TagModule} from "primeng/tag";
import {CardModule} from "primeng/card";
import {ProgressSpinnerModule} from "primeng/progressspinner";

@Component({
    selector: 'app-trips-list',
    imports: [CommonModule, TableModule, ButtonModule, TagModule, CardModule, ProgressSpinnerModule],
    templateUrl: './trips-list.component.html',
    styleUrl: './trips-list.component.scss'
})
export class TripsListComponent implements OnInit  {
  trips$: Observable<Trip[]> | undefined;
  loading$: Observable<boolean> | undefined;
  error$: Observable<any> | undefined;
  TripState = TripState;

  constructor(
    private store: Store<TripsState>,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.store.dispatch(loadTrips());

    this.trips$ = this.store.select(selectAllTrips);
    this.loading$ = this.store.select(selectTripsLoading);
    this.error$ = this.store.select(selectTripsError);
  }

  navigateToTripDetails(tripId: string): void {
    this.router.navigate(['/admin/trips', tripId]);
  }

  getStateClass(state: TripState): string {
    switch (state) {
      case TripState.DRAFT:
        return 'bg-blue-100 text-blue-800';
      case TripState.ACTIVE:
        return 'bg-green-100 text-green-800';
      case TripState.FINISHED:
        return 'bg-gray-100 text-gray-800';
      default:
        return '';
    }
  }

  getSeverity(state: TripState): "success" | "secondary" | "info" | "warn" | "danger" | "contrast" | undefined {
    switch (state) {
      case TripState.DRAFT:
        return 'info';
      case TripState.ACTIVE:
        return 'success';
      case TripState.FINISHED:
        return 'secondary';
      default:
        return 'info';
    }
  }
}
