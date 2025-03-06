import { createAction, props } from '@ngrx/store';
import {User} from "../../../../types/user";

export const initAuth = createAction('[Auth] Init');
export const initAuthSuccess = createAction('[Auth] Init Success', props<{ token: string }>());
export const initAuthFailure = createAction('[Auth] Init Failure');

export const refreshToken = createAction('[Auth] Refresh Token');
export const refreshTokenSuccess = createAction('[Auth] Refresh Token Success', props<{ token: string }>());
export const refreshTokenFailure = createAction('[Auth] Refresh Token Failure');

export const loadUser = createAction('[Auth] Get User Info');
export const loadUserSuccess = createAction('[Auth] Get User Info Success', props<{ user: User }>());
export const loadUserFailure = createAction('[Auth] Get User Info Failure');

export const logout = createAction('[Auth] Logout');
export const logoutSuccess = createAction('[Auth] Logout Success');
export const logoutFailure = createAction('[Auth] Logout Failure');
