import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { ChartModule } from 'primeng/chart';

@Component({
  selector: 'app-reservations-stats',
  standalone: true,
  imports: [CommonModule, CardModule, ChartModule],
  templateUrl: './reservations-stats.component.html',
  styleUrl: './reservations-stats.component.scss'
})
export class ReservationsStatsComponent implements OnInit {
  nextTripName: string = 'City Tour';
  nextTripDestination: string = 'Paris';
  reservations: number = 25;
  availablePlaces: number = 25;
  occupancyRate: number = 100;
  
  chartData: any;
  chartOptions: any;
  
  ngOnInit() {
    this.calculateOccupancyRate();
    this.initializeChart();
  }
  
  private calculateOccupancyRate() {
    if (this.availablePlaces > 0) {
      this.occupancyRate = Math.round((this.reservations / this.availablePlaces) * 100);
    } else {
      this.occupancyRate = 0;
    }
  }
  
  private initializeChart() {
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--text-color') || '#495057';
    const surfaceBorder = documentStyle.getPropertyValue('--surface-border') || '#dfe7ef';
    
    this.chartData = {
      labels: ['Reservations', 'Available'],
      datasets: [
        {
          data: [this.reservations, this.availablePlaces - this.reservations],
          backgroundColor: ['#4338ca', '#e2e8f0'],
          hoverBackgroundColor: ['#3730a3', '#cbd5e1']
        }
      ]
    };
    
    this.chartOptions = {
      cutout: '60%',
      plugins: {
        legend: {
          position: 'bottom',
          labels: {
            color: textColor
          }
        },
        tooltip: {
          callbacks: {
            label: (context: any) => {
              const label = context.label || '';
              const value = context.raw || 0;
              const total = context.dataset.data.reduce((acc: number, data: number) => acc + data, 0);
              const percentage = Math.round((value / total) * 100);
              return `${label}: ${value} (${percentage}%)`;
            }
          }
        }
      },
      responsive: true,
      maintainAspectRatio: false
    };
  }
}