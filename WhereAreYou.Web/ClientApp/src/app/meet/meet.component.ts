import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { MeetApiClientService } from '../services/meet-api-client.service';
import { AgmCoreModule } from '@agm/core';
import { Location } from '../models/location';
import { Router, ActivatedRoute } from '@angular/router';
import { timer } from 'rxjs';
import { ClipboardService } from 'ngx-clipboard';
import { AppComponent } from '../app.component';
import { ErrorType } from '../models/error-type';
import { ErrorResponse } from '../models/error-response';
import { BsModalRef, BsModalService, setTheme } from 'ngx-bootstrap';
import { UsersDialogComponent } from '../users-dialog/users-dialog.component';
import { MeetResponse } from '../models/meet-response';
import { TokenStorageServiceService } from './../services/token-storage-service.service';
import { Token } from '../models/token';

@Component({
  selector: 'app-meet',
  templateUrl: './meet.component.html',
  styleUrls: ['./meet.component.css']
})

export class MeetComponent implements OnInit, AfterViewInit, OnDestroy {
  id: number;
  token: Token;
  public currentMeet: MeetResponse;
  inviteHash: any;

  get geoSettings(): PositionOptions {
    return {
      enableHighAccuracy: false,
      timeout: 60000,
      maximumAge: Infinity
    }
  }

  get usersMarkerIcon(): string {
    return "https://maps.google.com/mapfiles/kml/paddle/grn-circle.png";
  }

  get currentUserMarkerIcon(): string {
    return "https://maps.google.com/mapfiles/kml/paddle/red-circle.png";
  }

  constructor(
    private meetApiClient: MeetApiClientService,
    private router: Router,
    private appComponent: AppComponent,
    private modalService: BsModalService,
    private modalRef: BsModalRef,
    private activatedRoute: ActivatedRoute,
    private clipboardService: ClipboardService,
    private tokenStorageService: TokenStorageServiceService) {
    setTheme('bs4');
  }

  async initTimer(): Promise<void> {
    var refresh = timer(1000, 1000);
    refresh.subscribe(async s => await this.reloadMeet());
  }

  async reloadMeet(): Promise<void> {
    if (this.token) {
      this.currentMeet = await this.meetApiClient.loadMeet(this.token.userData.meetInviteHash, this.token);
    }
  }

  handleGeoLocationExceptions(self: this): PositionErrorCallback {
    return (error) => {
      self.appComponent.dialogError(error.message, ErrorType.Critical);
    };
  }

  convertToLocation(f: Position) {
    let result: Location = {
      latitude: f.coords.latitude,
      longitude: f.coords.longitude
    }

    return result;
  }

  setPosition(self: this, f: Position) {
    this.currentMeet.currentUser = {
      user: self.token.userData.user,
      location: this.convertToLocation(f)
    };
  }

  initTracker(): void {
    let self = this;
    navigator.geolocation.getCurrentPosition(this.addPosition(self), this.handleGeoLocationExceptions(self), self.geoSettings);
    this.initWatchPosition(self);
  }

  initWatchPosition(self: this) {
    this.id = navigator.geolocation.watchPosition(this.updatePosition(self), this.handleGeoLocationExceptions(self), self.geoSettings);
  }

  addPosition(self: this): PositionCallback {
    return (f) => {
      if (this.currentMeet) {
        this.setPosition(self, f);
        self.meetApiClient.addPosition(this.convertToLocation(f), this.token); //TODO: Async?
        self.initWatchPosition(self);
      }
    };
  }

  updatePosition(self: this): PositionCallback {
    return (w) => {
      if (this.currentMeet) {
        this.setPosition(self, w);
        self.meetApiClient.updatePosition(this.convertToLocation(w), this.token);
      };
    }
  }

  openUsersList() {
    this.modalRef = this.modalService.show(UsersDialogComponent, {
      initialState: {
        currentMeet: this.currentMeet
      }
    });
  }

  copyInviteUrl() {
    this.clipboardService.copyFromContent(this.currentMeet.meet.inviteUrl);
  }

  errorHandler(error): void {
    if (error.error && error.error instanceof ErrorResponse) {
      this.appComponent.dialogError("Lokalizační chyba: ".concat(error.error), ErrorType.Error);
    }

    else {
      this.appComponent.dialogError("Nepodařilo se otevřít setkání pravděpdoboně z důvodů problémů na straně síťového připojení. Zkuste to prosím znovu, případně si vytvořte nové.", ErrorType.Error);
    }
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

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe(params => {
      this.inviteHash = params["inviteHash"];
      if (!this.inviteHash) {
        throw new Error("Invite hash route parameter is not defined.");
      }

      this.token = this.tokenStorageService.getToken(this.inviteHash);

      if (!this.token) {
        this.router.navigate(['invite', this.inviteHash]);
      }
    });
  }

  closeMeet(): void {
    this.router.navigate(['']);
  }

  ngOnDestroy(): void {
    this.router.navigate(['invite']);
  }
}
