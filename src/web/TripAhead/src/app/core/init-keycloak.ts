import {
  createInterceptorCondition,
  IncludeBearerTokenCondition,
  ProvideKeycloakOptions,
  INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, withAutoRefreshToken, AutoRefreshTokenService, UserActivityService
} from 'keycloak-angular';

// Provider for Keycloak Bearer Interceptor
const urlCondition = createInterceptorCondition<IncludeBearerTokenCondition>({
  urlPattern: /^(http:\/\/localhost:8181)(\/.*)?$/i,
  bearerPrefix: 'Bearer'
});

// Provider for Keycloak Initialization
export const keycloakOptions: ProvideKeycloakOptions = {
  config: {
    url: 'http://localhost:8080', // URL of the Keycloak server
    realm: 'tripahead', // Realm to be used in Keycloak
    clientId: 'angular-client' // Client ID for the application in Keycloak
  },
  initOptions: {
    onLoad: 'check-sso',
    silentCheckSsoRedirectUri:
      window.location.origin + '/assets/silent-check-sso.html',
    checkLoginIframe: false,
    flow: 'standard',
    redirectUri: 'http://localhost:4200',
  },
  features: [
    withAutoRefreshToken({
      onInactivityTimeout: 'logout',
      sessionTimeout: 60000
    })
  ],
  providers: [
    AutoRefreshTokenService,
    UserActivityService,
    {
      provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG,
      useValue: [urlCondition]
    }
  ]
};
