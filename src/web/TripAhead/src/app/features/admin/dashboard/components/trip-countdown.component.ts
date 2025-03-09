import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { Subscription, interval } from 'rxjs';

interface NextTrip {
  name: string;
  destination: string;
  startDate: Date;
}

@Component({
  selector: 'app-trip-countdown',
  standalone: true,
  imports: [CommonModule, CardModule],
  templateUrl: './trip-countdown.component.html',
  styleUrl: './trip-countdown.component.scss'
})
export class TripCountdownComponent implements OnInit, OnDestroy {
  nextTrip: NextTrip = {
    name: 'City Tour',
    destination: 'Paris',
    startDate: new Date('2025-04-05')
  };
  
  daysLeft: number = 0;
  hoursLeft: number = 0;
  minutesLeft: number = 0;
  secondsLeft: number = 0;
  
  private timerSubscription?: Subscription;
  
  ngOnInit() {
    this.updateCountdown();
    this.timerSubscription = interval(1000).subscribe(() => {
      this.updateCountdown();
    });
  }
  
  ngOnDestroy() {
    if (this.timerSubscription) {
      this.timerSubscription.unsubscribe();
    }
  }
  
  private updateCountdown() {
    const currentDate = new Date();
    const difference = this.nextTrip.startDate.getTime() - currentDate.getTime();
    
    if (difference > 0) {
      this.daysLeft = Math.floor(difference / (1000 * 60 * 60 * 24));
      this.hoursLeft = Math.floor((difference % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      this.minutesLeft = Math.floor((difference % (1000 * 60 * 60)) / (1000 * 60));
      this.secondsLeft = Math.floor((difference % (1000 * 60)) / 1000);
    } else {
      this.daysLeft = 0;
      this.hoursLeft = 0;
      this.minutesLeft = 0;
      this.secondsLeft = 0;
    }
  }
}