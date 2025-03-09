import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { InputNumberModule } from 'primeng/inputnumber';
import { CardModule } from 'primeng/card';

@Component({
    selector: 'app-details',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        InputTextModule,
        CalendarModule,
        DropdownModule,
        InputNumberModule,
        CardModule
    ],
    templateUrl: './details.component.html',
    styleUrl: './details.component.scss'
})
export class DetailsComponent {
    tripName: string = '';
    tripDescription: string = '';
    startDate: Date | null = null;
    endDate: Date | null = null;
    destination: string = '';
    price: number = 0;
    maxParticipants: number = 0;
    page: string = '';

    statusOptions = [
        { label: 'Draft', value: 'DRAFT' },
        { label: 'Active', value: 'ACTIVE' },
        { label: 'Completed', value: 'COMPLETED' },
        { label: 'Cancelled', value: 'CANCELLED' }
    ];

    selectedStatus = this.statusOptions[0];
}
