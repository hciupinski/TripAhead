import { Component, Injectable } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Trips } from "../types/trip";

@Injectable()
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'trips';
  trips: Trips | null = null;

  private tripsApiUrl = '/trips.api/trips';

  constructor(private http: HttpClient) {
    http.get<Trips>(this.tripsApiUrl).subscribe({
      next: result => this.trips = result,
      error: console.error
    });
  }
}
