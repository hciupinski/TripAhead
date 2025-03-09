import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { TabsModule } from 'primeng/tabs';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';

import { DetailsComponent } from './sections/details/details.component';
import { ClientsComponent } from './sections/clients/clients.component';
import { RoomsComponent } from './sections/rooms/rooms.component';
import { FeaturesComponent } from './sections/features/features.component';

@Component({
    selector: 'app-trip-details',
    standalone: true,
    imports: [
        CommonModule,
        TabsModule,
        ButtonModule,
        TooltipModule,
        ToolbarModule,
        ConfirmDialogModule,
        DetailsComponent,
        ClientsComponent,
        RoomsComponent,
        FeaturesComponent
    ],
    providers: [ConfirmationService, MessageService],
    templateUrl: './trip-details.component.html',
    styleUrl: './trip-details.component.scss'
})
export class TripDetailsComponent implements OnInit {
    tripId: string | null = null;
    tripStatus: string = 'DRAFT';
    loading: boolean = false;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private confirmationService: ConfirmationService,
        private messageService: MessageService
    ) {}

    ngOnInit() {
        this.tripId = this.route.snapshot.paramMap.get('id');
        if (this.tripId) {
            this.loadTripDetails();
        }
    }

    loadTripDetails() {
        this.loading = true;
        // TODO: Implement actual API call to fetch trip details
        setTimeout(() => {
            // Mock data for now
            this.loading = false;
        }, 500);
    }

    saveTrip() {
        this.confirmationService.confirm({
            message: 'Are you sure you want to save these changes?',
            accept: () => {
                // TODO: Implement save logic
                this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Trip saved successfully' });
            }
        });
    }

    cancelChanges() {
        this.confirmationService.confirm({
            message: 'Are you sure you want to cancel? All unsaved changes will be lost.',
            accept: () => {
                this.router.navigate(['/admin/trips']);
            }
        });
    }

    activateTrip() {
        this.confirmationService.confirm({
            message: 'Are you sure you want to activate this trip? This will make it visible to clients.',
            accept: () => {
                // TODO: Implement activate logic
                this.tripStatus = 'ACTIVE';
                this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Trip activated successfully' });
            }
        });
    }
}
