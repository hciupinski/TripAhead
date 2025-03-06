// src/app/store/auth/auth.effects.ts
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as AuthActions from './auth.actions';

import { catchError, from, map, mergeMap, of, switchMap, timer } from 'rxjs';
import {KeycloakService} from "keycloak-angular";
import {loadTrips, loadTripsFailure, loadTripsSuccess} from "../trips/trips.actions";
import {loadUser, loadUserFailure, loadUserSuccess} from "./auth.actions";
import {KeycloakProfile} from "keycloak-js/lib/keycloak";

@Injectable()
export class AuthEffects {
  constructor(
    private actions$: Actions,
    private keycloakService: KeycloakService,
  ) {}

  initAuth$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.initAuth),
      mergeMap(() =>
        from(this.keycloakService.init()).pipe(
          map(authenticated => {
            if (authenticated) {
              this.keycloakService.getToken().then(token => {
                return AuthActions.initAuthSuccess({ token });
              })
            }

            return AuthActions.initAuthFailure();
          }),
          catchError(() => of(AuthActions.initAuthFailure()))
        )
      )
    )
  );

  logout$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.logout),
      mergeMap(() =>
        from(this.keycloakService.logout()).pipe(
          map(() => {
            return AuthActions.logoutSuccess();
          })
        )
      )
    )
  );

  refreshToken$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.refreshToken),
      mergeMap(() =>
        from(this.keycloakService.updateToken()).pipe(
          map(success => {
            if (success) {
              this.keycloakService.getToken().then(token => {
                return AuthActions.refreshTokenSuccess({ token });
              })
            }
            return AuthActions.refreshTokenFailure();
          }),
          catchError(() => of(AuthActions.refreshTokenFailure()))
        )
      )
    )
  );

  // Automatic token refresh every 30 seconds (or another chosen interval)
  autoRefreshToken$ = createEffect(() =>
    timer(30000, 30000).pipe(
      switchMap(() => {
        // Attempt refresh if authenticated
        if (this.keycloakService.isLoggedIn()) {
          return of(AuthActions.refreshToken());
        }
        return of();
      })
    )
  );

  loadUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadUser),
      mergeMap(() =>
        from(this.keycloakService.loadUserProfile()).pipe(
          map((profile : KeycloakProfile) => {
            if (profile) {
              return AuthActions.loadUserSuccess({user: { id: profile.id, email: profile.email, firstName: profile.firstName, lastName: profile.lastName }});
            }
            return AuthActions.loadUserFailure();
          })
        )
      )
    )
  );
}
