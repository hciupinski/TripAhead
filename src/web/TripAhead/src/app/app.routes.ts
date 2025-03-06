import {Routes} from '@angular/router';
import {TripsListComponent} from "./features/admin/trips-list/trips-list.component";
import {TripDetailsComponent} from "./features/user/trip-details/trip-details.component";
import {HomeComponent} from "./features/common/home/home.component";
import {AuthGuard} from "./core/guards/auth.guard";

export const routes: Routes = [
  {
    path: 'not-secure',
    component: TripDetailsComponent,
  },
  {
    path: 'secure',
    component: TripsListComponent,
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  },
  {
    path: '',
    component: HomeComponent,
  },
];
