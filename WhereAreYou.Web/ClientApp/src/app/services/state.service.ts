import { Injectable, OnDestroy } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
import { SsoApiClientService } from "./sso-api-client.service";
import { RoomApiClientService } from "./room-api-client.service";
import { EnterTheRoom } from '../models/enter-the-room';
import { Room } from '../models/room';
import { Location } from '../models/location';

@Injectable({
    providedIn: 'root'
})
export class StateService implements OnDestroy {
    public roomSettings: EnterTheRoom;
    public currentRoom: Room;
    public currentLocation: Location;

    constructor() {
        this.roomSettings = new EnterTheRoom();
        this.currentRoom = null;
        this.currentLocation = null;
    }

    ResetForms() {
        this.roomSettings.inviteHash = "";
        this.roomSettings.inviteUrl = "";
        this.roomSettings.nickname = "";
    }

    CloseRoom(): void {
        this.currentRoom = null;
        localStorage.clear();
    }

    ngOnDestroy(): void {
        this.CloseRoom();
        this.ResetForms();
    }
}
