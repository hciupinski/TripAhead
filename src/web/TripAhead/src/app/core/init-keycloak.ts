import {KeycloakBearerInterceptor, KeycloakService} from 'keycloak-angular';
import {APP_INITIALIZER, Provider} from "@angular/core";
import {HTTP_INTERCEPTORS} from "@angular/common/http";

export function initializeKeycloak (keycloak: KeycloakService) {
    return () =>
        keycloak.init({
            // Configuration details for Keycloak
            config: {
                url: 'http://localhost:8080', // URL of the Keycloak server
                realm: 'tripahead', // Realm to be used in Keycloak
                clientId: 'angular-client' // Client ID for the application in Keycloak
            },
            loadUserProfileAtStartUp: true,
            initOptions: {
                onLoad: 'check-sso',
                silentCheckSsoRedirectUri:
                    window.location.origin + '/assets/silent-check-sso.html',
                checkLoginIframe: false,
                flow: 'standard',
                redirectUri: 'http://localhost:4200',
            },
            // Enables Bearer interceptor
            enableBearerInterceptor: true,
            // Prefix for the Bearer token
            bearerPrefix: 'Bearer',
            // URLs excluded from Bearer token addition (empty by default)
            bearerExcludedUrls: ['home']
        });
}

// Provider for Keycloak Bearer Interceptor
export const KeycloakBearerInterceptorProvider: Provider = {
    provide: HTTP_INTERCEPTORS,
    useClass: KeycloakBearerInterceptor,
    multi: true
};

// Provider for Keycloak Initialization
export const KeycloakInitializerProvider: Provider = {
    provide: APP_INITIALIZER,
    useFactory: initializeKeycloak,
    multi: true,
    deps: [KeycloakService]
}
