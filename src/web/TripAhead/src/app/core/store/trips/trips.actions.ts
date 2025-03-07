import { createAction, props } from '@ngrx/store';
import {Trip, TripsResponse} from "../../../../types/trip";

export const createTrip = createAction('[Trips] Create Trip');
export const createTripSuccess = createAction('[Trips] Create Trip Success', props<{ tripId: string }>());
export const createTripFailure = createAction('[Trips] Create Trip Failure', props<{ error: any }>());

export const loadTrips = createAction('[Trips] Load Trips');
export const loadTripsSuccess = createAction('[Trips] Load Trips Success', props<{ trips: Trip[] }>());
export const loadTripsFailure = createAction('[Trips] Load Trips Failure', props<{ error: any }>());
