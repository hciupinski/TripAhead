import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { inject } from '@angular/core';
import {AuthGuardData, createAuthGuard, KEYCLOAK_EVENT_SIGNAL} from 'keycloak-angular';
import Keycloak from "keycloak-js";

const isAccessAllowed = async (
  route: ActivatedRouteSnapshot,
  _: RouterStateSnapshot,
  authData: AuthGuardData
): Promise<boolean | UrlTree> => {
  const { authenticated, grantedRoles } = authData;
  const keycloak = inject(Keycloak);

  console.log("roles", grantedRoles);
  console.log("redirect", window.location.origin + _.url)
  if (!authenticated) {
    await keycloak.login({
      redirectUri: window.location.origin + _.url
    });
  }

  const requiredRole = route.data['roles'];
  if (!requiredRole) {
    return false;
  }

  const hasRequiredRole = (role: string): boolean =>
    Object.values(grantedRoles.realmRoles).some((roles) => roles.includes(role));

  if (authenticated && hasRequiredRole(requiredRole)) {
    return true;
  }

  const router = inject(Router);
  return router.parseUrl('/forbidden');
};

export const canActivateAuthRole = createAuthGuard<CanActivateFn>(isAccessAllowed);
