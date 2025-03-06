// src/app/store/auth/auth.selectors.ts
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthState } from './auth.reducer';

export const selectAuthState = createFeatureSelector<AuthState>('auth');

export const selectToken = createSelector(selectAuthState, state => state.token);
export const selectIsInitialized = createSelector(selectAuthState, state => state.initialized);
export const selectIsAuthenticated = createSelector(selectToken, token => !!token);
export const selectHasError = createSelector(selectAuthState, state => state.error);

export const selectUserProfile = createSelector(selectAuthState, state => state.user);
