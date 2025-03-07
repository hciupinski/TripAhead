import {TripsApiService} from "../../services/trips-api.service";
import {catchError, map, mergeMap, of} from "rxjs";
import {loadTrips, loadTripsFailure, loadTripsSuccess} from "./trips.actions";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import {Injectable} from "@angular/core";

@Injectable()
export class TripsEffect {
  loadTrips$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadTrips),
      mergeMap((action) =>
        this.tripsApiService.getTrips().pipe(
          map((response) =>
            loadTripsSuccess({ trips: response.trips })
          ),
          catchError((error) => of(loadTripsFailure({error})))
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private tripsApiService: TripsApiService
  ) {}
}
