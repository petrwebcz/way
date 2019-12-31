import { Injectable, OnDestroy } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
import { SsoApiClientService } from "./sso-api-client.service";
import { MeetApiClientService } from "./meet-api-client.service";
import { EnterTheMeet } from '../models/enter-the-meet';
import { MeetResponse } from '../models/meet-response';
import { Location } from '../models/location';
import { Position } from '../models/position';

@Injectable({
    providedIn: 'root'
})

export class StateService implements OnDestroy {
    public meetSettings: EnterTheMeet;
    public currentMeet: MeetResponse;

    constructor() {
        this.meetSettings = new EnterTheMeet();
        this.currentMeet = new MeetResponse();
        this.currentMeet.currentUser = new Position();
        this.currentMeet.centerPoint = new Location();
        this.currentMeet.users = new Array<Position>();
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
