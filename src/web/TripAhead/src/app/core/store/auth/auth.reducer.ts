// src/app/store/auth/auth.reducer.ts
import { createReducer, on } from '@ngrx/store';
import * as AuthActions from './auth.actions';
import {User} from "../../../../types/user";

export interface AuthState {
  token: string | null;
  user: User | null;
  initialized: boolean;
  error: boolean;
}

export const initialState: AuthState = {
  token: null,
  user: null,
  initialized: false,
  error: false
};

export const authReducer = createReducer(
  initialState,
  on(AuthActions.initAuth, state => ({ ...state, initialized: false, error: false })),
  on(AuthActions.initAuthSuccess, (state, { token }) => ({ ...state, token, initialized: true, error: false })),
  on(AuthActions.initAuthFailure, state => ({ ...state, token: null, initialized: true, error: true })),

  on(AuthActions.refreshTokenSuccess, (state, { token }) => ({ ...state, token })),
  on(AuthActions.refreshTokenFailure, state => ({ ...state, token: null })),

  on(AuthActions.loadUserSuccess, (state, { user }) => ({ ...state, user, error: false })),
  on(AuthActions.loadUserFailure, state => ({ ...state, user: null, error: true })),

  on(AuthActions.logout, state => ({ ...state, token: null, initialized: false }))
);
