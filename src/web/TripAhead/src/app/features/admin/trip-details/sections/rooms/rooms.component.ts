import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { TooltipModule } from 'primeng/tooltip';
import { ToolbarModule } from 'primeng/toolbar';
import {RippleModule} from "primeng/ripple";

interface Room {
    id: string;
    name: string;
    type: string;
    capacity: number;
    pricePerNight: number;
    available: number;
}

@Component({
    selector: 'app-rooms',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        TableModule,
        ButtonModule,
        DialogModule,
        DropdownModule,
        InputTextModule,
        InputNumberModule,
        TooltipModule,
        ToolbarModule,
        RippleModule
    ],
    templateUrl: './rooms.component.html',
    styleUrl: './rooms.component.scss'
})
export class RoomsComponent {
    rooms: Room[] = [
        {
            id: '1',
            name: 'Standard Room',
            type: 'SINGLE',
            capacity: 1,
            pricePerNight: 100,
            available: 10
        },
        {
            id: '2',
            name: 'Double Room',
            type: 'DOUBLE',
            capacity: 2,
            pricePerNight: 150,
            available: 8
        },
        {
            id: '3',
            name: 'Family Suite',
            type: 'SUITE',
            capacity: 4,
            pricePerNight: 300,
            available: 5
        }
    ];

    selectedRooms: Room[] = [];
    room: Room = this.createEmptyRoom();
    roomDialog: boolean = false;

    roomTypes = [
        { label: 'Single', value: 'SINGLE' },
        { label: 'Double', value: 'DOUBLE' },
        { label: 'Suite', value: 'SUITE' },
        { label: 'Apartment', value: 'APARTMENT' }
    ];

    createEmptyRoom(): Room {
        return {
            id: '',
            name: '',
            type: 'SINGLE',
            capacity: 1,
            pricePerNight: 0,
            available: 0
        };
    }

    openNew() {
        this.room = this.createEmptyRoom();
        this.roomDialog = true;
    }

    editRoom(room: Room) {
        this.room = {...room};
        this.roomDialog = true;
    }

    deleteRoom(room: Room) {
        this.rooms = this.rooms.filter(r => r.id !== room.id);
    }

    hideDialog() {
        this.roomDialog = false;
    }

    saveRoom() {
        if (this.room.name.trim()) {
            if (this.room.id) {
                // Update existing room
                this.rooms = this.rooms.map(r => (r.id === this.room.id) ? this.room : r);
            } else {
                // Create new room with random ID
                this.room.id = this.createId();
                this.rooms.push(this.room);
            }

            this.roomDialog = false;
            this.room = this.createEmptyRoom();
        }
    }

    createId(): string {
        return Math.random().toString(36).substring(2, 9);
    }
}
