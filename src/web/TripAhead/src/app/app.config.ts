import {APP_INITIALIZER, ApplicationConfig, importProvidersFrom} from '@angular/core';
import {provideRouter} from '@angular/router';

import { routes } from './app.routes';

import {provideHttpClient, withInterceptors, withInterceptorsFromDi} from "@angular/common/http";
import {initializeKeycloak, KeycloakBearerInterceptorProvider, KeycloakInitializerProvider} from "./core/init-keycloak";
import {KeycloakAngularModule, KeycloakService} from "keycloak-angular";
import {provideStore} from "@ngrx/store";
import {provideEffects} from "@ngrx/effects";
import {authInterceptor} from "./core/interceptors/auth.interceptor";
import {authReducer} from "./core/store/auth/auth.reducer";
import {AuthEffects} from "./core/store/auth/auth.effects";
import {TripsEffect} from "./core/store/trips/trips.effects";
import {tripsReducer} from "./core/store/trips/trips.reducer";
import {provideClientHydration} from "@angular/platform-browser";

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withInterceptorsFromDi()),
    KeycloakInitializerProvider,
    KeycloakBearerInterceptorProvider,
    KeycloakService,
    provideClientHydration(),
    provideRouter(routes),
    provideStore({ auth: authReducer, trips: tripsReducer }),
    provideEffects([AuthEffects, TripsEffect]),
  ]
};
