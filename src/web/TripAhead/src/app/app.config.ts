import {APP_INITIALIZER, ApplicationConfig} from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';

import {provideHttpClient} from "@angular/common/http";
import {initKeycloak} from "./core/init-keycloak";
import {KeycloakAngularModule, KeycloakService} from "keycloak-angular";

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    { provide: KeycloakAngularModule, useValue: KeycloakAngularModule },
    {
      provide: APP_INITIALIZER,
      useFactory: (keycloak: KeycloakService, store: Store) => () => {
        store.dispatch(authInit());
      },
      deps: [KeycloakService, Store],
      multi: true
    }
  ]
};
