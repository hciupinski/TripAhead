import {createFeatureSelector, createSelector} from "@ngrx/store";
import {TripsState} from "./trips.reducer";

export const selectTripsState =
  createFeatureSelector<TripsState>('trips');

export const selectAllTrips = createSelector(
  selectTripsState,
  (state: TripsState) => state.trips
);

export const selectTripsLoading = createSelector(
  selectTripsState,
  (state: TripsState) => state.loading
);

export const selectTripsError = createSelector(
  selectTripsState,
  (state: TripsState) => state.error
);
