import { Component } from '@angular/core';
import { FluidModule } from "primeng/fluid";
import { OverlayModule } from "primeng/overlay";
import { SelectModule } from "primeng/select";
import { ButtonModule } from "primeng/button";
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { InputNumberModule } from 'primeng/inputnumber';
import { CardModule } from 'primeng/card';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-create-trip',
  standalone: true,
  imports: [
    FluidModule,
    OverlayModule,
    SelectModule,
    ButtonModule,
    ReactiveFormsModule,
    InputTextModule,
    CalendarModule,
    InputNumberModule,
    CardModule,
    ToastModule,
    CommonModule,
  ],
  providers: [MessageService],
  templateUrl: './create-trip.component.html',
  styleUrl: './create-trip.component.scss'
})
export class CreateTripComponent {
  tripForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private messageService: MessageService
  ) {
    this.tripForm = this.fb.group({
      name: ['', [Validators.required]],
      destination: ['', [Validators.required]],
      description: ['', [Validators.required]],
      startDate: [null, [Validators.required]],
      endDate: [null, [Validators.required]],
      maxCapacity: [null, [Validators.required, Validators.min(1)]],
      price: [null, [Validators.required, Validators.min(0)]]
    });
  }

  onSubmit() {
    if (this.tripForm.invalid) {
      this.tripForm.markAllAsTouched();
      return;
    }

    // Here you would typically call your service to create the trip
    // For demo purposes, we'll just navigate to a mock ID
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: 'Trip created successfully'
    });

    setTimeout(() => {
      this.router.navigate(['/admin/trips', '123']);
    }, 1500);
  }

  onCancel() {
    this.tripForm.reset();
  }
}
