import { Injectable, OnDestroy } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
import { EnterTheMeet } from '../models/enter-the-meet';
import { MeetResponse } from '../models/meet-response';
import { Location } from '../models/location';
import { Position } from '../models/position';
import { UserData } from '../models/user-data';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})

export class StateService implements OnDestroy {
  public meetSettings: EnterTheMeet;
  public currentMeet: MeetResponse;

  public get accessToken(): string {

    var token = localStorage.getItem("access-token");

    if (!token) this.CloseMeet();

    return token;
  }

  public get userData(): UserData {

    var decoded = jwt_decode(this.accessToken)

    if (!decoded) throw new Error("Error in decode jwt token");

    console.log(decoded);

    var userDataJson = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata"]

    var userData: UserData = JSON.parse(userDataJson);

    return userData;

  }

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
