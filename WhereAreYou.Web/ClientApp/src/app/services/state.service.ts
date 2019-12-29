import { Injectable, OnDestroy } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
import { SsoApiClientService } from "./sso-api-client.service";
import { MeetApiClientService } from "./meet-api-client.service";
import { EnterTheMeet } from '../models/enter-the-meet';
import { Meet } from '../models/meet';
import { Location } from '../models/location';

@Injectable({
    providedIn: 'root'
})
export class StateService implements OnDestroy {
    public meetSettings: EnterTheMeet;
    public currentMeet: Meet;
    public currentLocation: Location;

    constructor() {
        this.meetSettings = new EnterTheMeet();
        this.currentMeet = null;
        this.currentLocation = null;
    }

    ResetForms() {
        this.meetSettings.inviteHash = "";
        this.meetSettings.inviteUrl = "";
        this.meetSettings.nickname = "";
    }

    CloseMeet(): void {
        this.currentMeet = null;
        localStorage.clear();
    }

    ngOnDestroy(): void {
        this.CloseMeet();
        this.ResetForms();
    }
}
