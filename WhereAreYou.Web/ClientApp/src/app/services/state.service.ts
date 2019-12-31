import { Injectable, OnDestroy } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
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

    constructor(
        private router: Router) {
        this.meetSettings = new EnterTheMeet();
        this.currentMeet = new MeetResponse();
    }

    ResetForms() {
        this.meetSettings.inviteHash = "";
        this.meetSettings.inviteUrl = "";
        this.meetSettings.nickname = "";
    }

    CloseMeet(): void {
        this.currentMeet = new MeetResponse();
        localStorage.clear();
        this.router.navigate(['']);
    }

    ngOnDestroy(): void {
        this.CloseMeet();
        this.ResetForms();
    }
}
