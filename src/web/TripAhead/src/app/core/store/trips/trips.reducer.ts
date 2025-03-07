import {Trip} from "../../../../types/trip";
import {createReducer, on} from "@ngrx/store";
import {loadTrips, loadTripsFailure, loadTripsSuccess} from "./trips.actions";

export interface TripsState {
  error: any;
  loading: boolean;
  trips: Trip[];
}

export const initialState: TripsState = {
  trips: [],
  loading: false,
  error: null,
};

export const tripsReducer = createReducer(
  initialState,
  on(loadTrips, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(loadTripsSuccess, (state, { trips }) => ({
    ...state,
    trips,
    loading: false,
  })),
  on(loadTripsFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);
