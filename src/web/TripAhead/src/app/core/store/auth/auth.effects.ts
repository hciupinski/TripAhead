// src/app/store/auth/auth.effects.ts
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as AuthActions from './auth.actions';

import { catchError, from, map, mergeMap, of, switchMap, timer } from 'rxjs';
import {loadUser} from "./auth.actions";
import Keycloak, {KeycloakProfile} from 'keycloak-js';

@Injectable()
export class AuthEffects {
  constructor(
    private actions$: Actions,
    private keycloakService: Keycloak,
  ) {}

  initAuth$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.initAuth),
      mergeMap(() =>
        from(this.keycloakService.init()).pipe(
          map(authenticated => {
            if (authenticated) {
                return AuthActions.initAuthSuccess({ token : this.keycloakService.token! });
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
                return AuthActions.refreshTokenSuccess({ token : this.keycloakService.refreshToken! });
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
        if (this.keycloakService.authenticated) {
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
