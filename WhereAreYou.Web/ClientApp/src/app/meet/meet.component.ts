import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';
import { AgmCoreModule } from '@agm/core';
import { Location } from '../models/location';
import { Routes, Router, RouterModule } from '@angular/router';
import { timer } from 'rxjs';
import { ClipboardService } from 'ngx-clipboard';
import { AppComponent } from '../app.component';
import { ErrorType } from '../models/error-type';
import { ErrorResponse } from '../models/error-response';
import { BsModalRef, BsModalService, setTheme } from 'ngx-bootstrap';
import { UsersDialogComponent } from '../users-dialog/users-dialog.component';

@Component({
  selector: 'app-meet',
  templateUrl: './meet.component.html',
  styleUrls: ['./meet.component.css']
})

export class MeetComponent implements AfterViewInit, OnDestroy {
  get geoSettings(): PositionOptions {
    return {
      enableHighAccuracy: true,
      timeout: 30000,
      maximumAge: 0
    }
  }

  get usersMarkerIcon(): string {
    return "https://maps.google.com/mapfiles/kml/paddle/grn-circle.png";
  }

  get currentUserMarkerIcon(): string {
    return "https://maps.google.com/mapfiles/kml/paddle/red-circle.png";
  }

  constructor(
    public state: StateService,
    private meetApiClient: MeetApiClientService,
    private router: Router,
    private appComponent: AppComponent,
    private modalService: BsModalService,
    private modalRef: BsModalRef,
    private clipboardService: ClipboardService) {
    setTheme('bs4');
  }

  async ngAfterViewInit(): Promise<void> {

    await this.reloadMeet();

    if (navigator.geolocation) {
      await this.initTracker();
      await this.initTimer();
    }

    else {
      this.appComponent.dialogError("Bohužel, nemáte povoleno sdílení polohy ve Vašem prohlížeči, prosím povolte jej a otevřete setkání znovu.", ErrorType.Critical)
    }
  }

  async initTracker(): Promise<void> {
    let self = this;
    navigator.geolocation.watchPosition(this.updatePosition(self), this.handleGeoLocationExceptions(self), self.geoSettings);
    navigator.geolocation.getCurrentPosition(this.addPosition(self), this.handleGeoLocationExceptions(self), self.geoSettings);
  }

  private handleGeoLocationExceptions(self: this): PositionErrorCallback {
    return (error) => self.appComponent.dialogError(error.message, ErrorType.Critical);
  }

  private addPosition(self: this): PositionCallback {
    return async (f) => {
      this.state.currentMeet.currentUser = {
        user: null,
        location: {
          latitude: f.coords.latitude,
          longitude: f.coords.longitude
        }
      };
      await self.meetApiClient.addPosition(this.state.currentMeet.currentUser.location);
    };
  }

  private updatePosition(self: this): PositionCallback {
    return async (w) => {
      this.state.currentMeet.currentUser.location = {
        latitude: w.coords.latitude,
        longitude: w.coords.longitude
      };
      await self.meetApiClient.updatePosition(this.state.currentMeet.currentUser.location);
    };
  }

  async initTimer(): Promise<void> {
    var refresh = timer(1000, 2000);
    refresh.subscribe(async s => await this.reloadMeet());
  }

  async reloadMeet(): Promise<void> {
    if (this.state.userData != null)
      this.state.currentMeet = await this.meetApiClient.loadMeet(this.state.userData.meetInviteHash);
  }

  openUsersList() {
    this.modalRef = this.modalService.show(UsersDialogComponent, { initialState: {} });
  }

  copyInviteUrl() {
    this.clipboardService.copyFromContent(this.state.currentMeet.meet.inviteUrl);
  }

  errorHandler(error): void {
    if (error.error && error.error instanceof ErrorResponse) {
      this.appComponent.dialogErrorResponse(error.error);
    }

    else {
      this.appComponent.dialogError("Nepodařilo se otevřít setkání pravděpdoboně z důvodů problémů na straně síťového připojení. Zkuste to prosím znovu, případně si vytvořte nové.", ErrorType.Error);
    }
  }

  ngOnDestroy(): void {
    console.log("destroying meet component");
  }
}
