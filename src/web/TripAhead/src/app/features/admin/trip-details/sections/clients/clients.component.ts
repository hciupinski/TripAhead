import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { CardModule } from 'primeng/card';
import {RippleModule} from "primeng/ripple";

interface Client {
    id: string;
    name: string;
    email: string;
    phone: string;
    status: string;
}

@Component({
    selector: 'app-clients',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        TableModule,
        ButtonModule,
        ToolbarModule,
        InputTextModule,
        TooltipModule,
        CardModule,
      RippleModule
    ],
    templateUrl: './clients.component.html',
    styleUrl: './clients.component.scss'
})
export class ClientsComponent {
    clients: Client[] = [
        {
            id: '1',
            name: 'John Doe',
            email: 'john.doe@example.com',
            phone: '+123456789',
            status: 'CONFIRMED'
        },
        {
            id: '2',
            name: 'Jane Smith',
            email: 'jane.smith@example.com',
            phone: '+987654321',
            status: 'PENDING'
        }
    ];

    selectedClients: Client[] = [];
    client: Client = this.createEmptyClient();
    clientDialog: boolean = false;

    createEmptyClient(): Client {
        return {
            id: '',
            name: '',
            email: '',
            phone: '',
            status: 'PENDING'
        };
    }

    editClient(client: Client) {
        this.client = {...client};
        this.clientDialog = true;
    }

    deleteClient(client: Client) {
        // In a real app, you would call an API to delete the client
        this.clients = this.clients.filter(c => c.id !== client.id);
    }
}
