import {Routes} from '@angular/router';
import {HomeComponent} from "./features/common/home/home.component";
import {LayoutComponent as AdminLayoutComponent} from "./features/admin/layout/layout.component";
import {LayoutComponent as UserLayoutComponent} from "./features/user/layout/layout.component";
import {TripDetailsComponent as UserTripDetailsComponent} from "./features/user/trip-details/trip-details.component";
import {TripDetailsComponent as AdminTripDetailsComponent} from "./features/admin/trip-details/trip-details.component";
import {TripsListComponent} from "./features/admin/trips-list/trips-list.component";
import {ClientsComponent} from "./features/admin/trip-details/sections/clients/clients.component";
import {DetailsComponent} from "./features/admin/trip-details/sections/details/details.component";
import {FeaturesComponent} from "./features/admin/trip-details/sections/features/features.component";
import {RoomsComponent} from "./features/admin/trip-details/sections/rooms/rooms.component";
import {NotFoundComponent} from "./features/common/not-found/not-found.component";
import {canActivateAuthRole} from "./core/guards/auth.guard";

export const routes: Routes = [
  {
    path: 'offers',
    component: HomeComponent,
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [canActivateAuthRole],
    data: { roles: ['admin'] },
    children: [
      {
        path: 'trips',
        component: TripsListComponent,
      },
      {
        path: 'trips/{tripId}',
        component: AdminTripDetailsComponent,
        children: [
          {
            path: 'clients',
            component: ClientsComponent,
          },
          {
            path: 'details',
            component: DetailsComponent,
          },
          {
            path: 'features',
            component: FeaturesComponent,
          },
          {
            path: 'rooms',
            component: RoomsComponent,
          }
        ]
      },
      {
        path: '',
        redirectTo: 'trips',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: 'trips',
    component: UserLayoutComponent,
    // canActivate: [canActivateAuthRole],
    // data: { roles: ['client'] },
    children: [
      {
        path: '{tripId}',
        component: UserTripDetailsComponent,
      }
    ]
  },
  {
    path: '',
    redirectTo: '/offers',
    pathMatch: 'full'
  },
  { path: '**', component: NotFoundComponent }
];
