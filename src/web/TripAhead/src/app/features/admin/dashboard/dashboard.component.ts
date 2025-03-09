import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TripsTableComponent } from './components/trips-table.component';
import { TripCountdownComponent } from './components/trip-countdown.component';
import { ReservationsStatsComponent } from './components/reservations-stats.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    TripsTableComponent,
    TripCountdownComponent,
    ReservationsStatsComponent
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  
}
