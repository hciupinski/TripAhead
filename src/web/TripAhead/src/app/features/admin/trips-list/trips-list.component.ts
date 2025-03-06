import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {Trip} from "../../../../types/trip";
import {Store} from "@ngrx/store";
import {TripsState} from "../../../core/store/trips/trips.reducer";
import {selectAllTrips, selectTripsError, selectTripsLoading} from "../../../core/store/trips/trips.selector";
import {CommonModule} from "@angular/common";
import {loadTrips} from "../../../core/store/trips/trips.actions";

@Component({
  selector: 'app-trips-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './trips-list.component.html',
  styleUrl: './trips-list.component.scss'
})
export class TripsListComponent implements OnInit  {
  trips$: Observable<Trip[]> | undefined;
  loading$: Observable<boolean> | undefined;
  error$: Observable<any> | undefined;

  constructor(private store: Store<TripsState>) {
  }

  ngOnInit(): void {
    this.store.dispatch(loadTrips());

    this.trips$ = this.store.select(selectAllTrips);

    this.loading$ = this.store.select(selectTripsLoading);
    this.error$ = this.store.select(selectTripsError);
  }

  protected readonly JSON = JSON;
}
