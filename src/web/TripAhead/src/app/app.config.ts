import {ApplicationConfig } from '@angular/core';
import {provideRouter} from '@angular/router';

import { routes } from './app.routes';

import {provideHttpClient, withInterceptors} from "@angular/common/http";
import {
  keycloakOptions,
} from "./core/init-keycloak";
import {includeBearerTokenInterceptor, provideKeycloak} from "keycloak-angular";
import {provideStore} from "@ngrx/store";
import {provideEffects} from "@ngrx/effects";
import {authReducer} from "./core/store/auth/auth.reducer";
import {AuthEffects} from "./core/store/auth/auth.effects";
import {TripsEffect} from "./core/store/trips/trips.effects";
import {tripsReducer} from "./core/store/trips/trips.reducer";
import {provideClientHydration} from "@angular/platform-browser";
import {providePrimeNG} from "primeng/config";
import {provideAnimationsAsync} from "@angular/platform-browser/animations/async";
import Aura from '@primeng/themes/aura';

export const appConfig: ApplicationConfig = {
  providers: [
    provideKeycloak(keycloakOptions),
    provideRouter(routes),
    provideHttpClient(withInterceptors([includeBearerTokenInterceptor])),
    provideClientHydration(),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Aura
      }
    }),
    provideStore({ auth: authReducer, trips: tripsReducer }),
    provideEffects([AuthEffects, TripsEffect]),
  ]
};
