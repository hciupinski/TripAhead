import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';

interface Trip {
  id: string;
  name: string;
  destination: string;
  startDate: Date;
  endDate: Date;
  availablePlaces: number;
  reservations: number;
  status: string;
}

@Component({
  selector: 'app-trips-table',
  standalone: true,
  imports: [CommonModule, TableModule, ButtonModule],
  templateUrl: './trips-table.component.html',
  styleUrl: './trips-table.component.scss'
})
export class TripsTableComponent implements OnInit {
  trips: Trip[] = [];
  
  ngOnInit() {
    // Mock data - replace with actual API call
    this.trips = [
      {
        id: '1',
        name: 'Summer Beach Vacation',
        destination: 'Maldives',
        startDate: new Date('2025-06-15'),
        endDate: new Date('2025-06-25'),
        availablePlaces: 20,
        reservations: 12,
        status: 'Open'
      },
      {
        id: '2',
        name: 'Winter Mountain Retreat',
        destination: 'Swiss Alps',
        startDate: new Date('2025-12-10'),
        endDate: new Date('2025-12-17'),
        availablePlaces: 15,
        reservations: 10,
        status: 'Open'
      },
      {
        id: '3',
        name: 'City Tour',
        destination: 'Paris',
        startDate: new Date('2025-04-05'),
        endDate: new Date('2025-04-10'),
        availablePlaces: 25,
        reservations: 25,
        status: 'Fully Booked'
      }
    ];
  }
}