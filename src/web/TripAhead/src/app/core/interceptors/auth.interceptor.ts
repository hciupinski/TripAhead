import {inject} from '@angular/core';
import { HttpInterceptorFn} from '@angular/common/http';
import { Store } from '@ngrx/store';
import { switchMap } from 'rxjs';
import {selectToken} from "../store/auth/auth.selectors";

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const store = inject(Store);

    return store.select(selectToken).pipe(
      switchMap(token => {
        if (token) {
          const cloned = req.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
          return next(cloned);
        }
        return next(req);
      })
    );
};
