import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
import { EnterTheMeet } from '../models/enter-the-meet';
import { MeetResponse } from '../models/meet-response';
import { Location } from '../models/location';
import { Position } from '../models/position';
import { UserData } from '../models/user-data';
import { MeetApiClientService } from '../services/meet-api-client.service';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})


export class StateService implements OnDestroy {
  public meetSettings: EnterTheMeet;
  public currentMeet: MeetResponse;

  public get accessToken(): string {
    return sessionStorage.getItem("access-token");
  }

  public get userData(): UserData {
    if (!this.accessToken) {
      return null;
    }

    var decoded = jwt_decode(this.accessToken)

    if (!decoded) {
      throw new Error("Error in decode jwt token");
    }

    var userDataJson = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata"]
    var userData: UserData = JSON.parse(userDataJson);

    return userData;
  }

  constructor(
    private router: Router,
    private meetApiClient: MeetApiClientService) {
    this.meetSettings = new EnterTheMeet();
  }

  public async initApp(): Promise<void> {
    if (this.accessToken) {
      this.currentMeet = await this.meetApiClient.loadMeet(this.userData.meetInviteHash);
    }
  }

  RedirectToMeet(): void {
    this.router.navigate(['meet', this.currentMeet.meet.inviteHash]);
  }

  RedirectToSelectNickname(): void {
    this.router.navigate(['select-nickname']);
  }

  RedirectToInviteUrl(): void {
    this.router.navigate(['']);
  }

  RedirectToOpenMeet(): void {
    this.router.navigate(['open']);
  }

  CloseMeet(): void {
    this.currentMeet = null;
    this.router.navigate(['']);
  }

  ngOnDestroy(): void {
    this.CloseMeet();
  }
}
