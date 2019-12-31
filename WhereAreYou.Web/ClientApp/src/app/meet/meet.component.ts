import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';
import { AgmCoreModule } from '@agm/core';
import { Location } from '../models/location';
import { Routes, Router, RouterModule } from '@angular/router';
import { timer } from 'rxjs';
import { ClipboardService } from 'ngx-clipboard';

@Component({
    selector: 'app-meet',
    templateUrl: './meet.component.html',
    styleUrls: ['./meet.component.css']
})

export class MeetComponent implements OnInit, AfterViewInit, OnDestroy {
    private timer 
    get geoSettings(): PositionOptions {
        return {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        }
    }

    get usersMarkerIcon(): string {
        return "http://maps.google.com/mapfiles/kml/paddle/grn-circle.png";
    }

    get currentUserMarkerIcon(): string {
        return "http://maps.google.com/mapfiles/kml/paddle/red-circle.png";
    }

    constructor(
        public state: StateService,
        private meetApiClient: MeetApiClientService,
        private router: Router,
        private clipboardService: ClipboardService) { }

    async ngOnInit(): Promise<void> {
        this.checkIsMeetOpened();
    }

    async ngAfterViewInit(): Promise<void> {
        if (navigator.geolocation)
            await this.initTracker();
        else
            throw new Error("Bohužel, nemáte povoleno sdílení polohy ve Vašem prohlížeči.")
        await this.initTimer();
    }

    copyInviteUrl() {
        this.clipboardService.copyFromContent(this.state.meetSettings.inviteUrl);
    }

    async initTracker(): Promise<void> {
        let self = this;

        navigator.geolocation.getCurrentPosition(
            async (f) => {
                this.state.currentMeet.currentUser = {
                    user: null,
                    location: {
                        latitude: f.coords.latitude,
                        longitude: f.coords.longitude
                    }
                }

                await self.meetApiClient.addPosition(this.state.currentMeet.currentUser.location);

                navigator.geolocation.watchPosition(
                    async (u) => await self.meetApiClient.updatePosition(this.state.currentMeet.currentUser.location),
                    (e) => console.log(e),
                    self.geoSettings)
            },
            (e) => console.log(e),
            self.geoSettings)
    }


    async initTimer(): Promise<void> {
        var refresh = timer(1000, 2000);
        refresh.subscribe(s => this.reloadMeet());
    }

    async reloadMeet(): Promise<void> {
        this.state.currentMeet = await this.meetApiClient.loadMeet(this.state.meetSettings.inviteHash);
    }

    checkIsMeetOpened(): void {
        if (!this.state.currentMeet) {
            this.router.navigate(['']);
        }
    }

    ngOnDestroy(): void {
        //TODO:this.time destrory (closemeet)
    }
}
