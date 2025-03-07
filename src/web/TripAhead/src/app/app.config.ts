import {ApplicationConfig } from '@angular/core';
import {provideRouter} from '@angular/router';

import { routes } from './app.routes';

import {provideHttpClient, withInterceptorsFromDi} from "@angular/common/http";
import {KeycloakBearerInterceptorProvider, KeycloakInitializerProvider} from "./core/init-keycloak";
import {KeycloakService} from "keycloak-angular";
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
    provideHttpClient(withInterceptorsFromDi()),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Aura
      }
    }),
    KeycloakInitializerProvider,
    KeycloakBearerInterceptorProvider,
    KeycloakService,
    provideClientHydration(),
    provideRouter(routes),
    provideStore({ auth: authReducer, trips: tripsReducer }),
    provideEffects([AuthEffects, TripsEffect]),
  ]
};
