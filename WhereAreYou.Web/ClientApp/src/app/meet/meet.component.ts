import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';
import { AgmCoreModule } from '@agm/core';
import { Location } from '../models/location';
import { Routes, Router, RouterModule } from '@angular/router';
import { timer } from 'rxjs';

@Component({
    selector: 'app-meet',
    templateUrl: './meet.component.html',
    styleUrls: ['./meet.component.css']
})

export class MeetComponent implements OnInit, AfterViewInit, OnDestroy {
    get geoSettings(): PositionOptions {
        return {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        }
    }

    constructor(
        public state: StateService,
        private meetApiClient: MeetApiClientService,
        private ssoApiClient: SsoApiClientService,
        private router: Router) { }

    ngOnInit(): void {
        this.checkIsMeetOpened();
    }

    ngAfterViewInit(): void {
        this.initTimer();
        this.initTracker();
    }

    ngOnDestroy(): void {

    }

    async initTracker(): Promise<void> {
        let self = this;
        navigator.geolocation.getCurrentPosition(
            async (f) => {
                console.log("Add init posiiton: " + f.coords.latitude + " / " + f.coords.longitude);
                await self.meetApiClient.addPosition(
                    {
                        latitude: f.coords.latitude,
                        longitude: f.coords.longitude
                    });

                navigator.geolocation.watchPosition(
                    (u) => {
                        console.log("Update position: " + u.coords.latitude + " / " + u.coords.longitude);
                        self.meetApiClient.updatePosition(
                            {
                                latitude: u.coords.latitude,
                                longitude: u.coords.longitude
                            })
                    },
                    (e) => console.log(e),
                    self.geoSettings)
            },
            (e) => console.log(e),
            self.geoSettings)
    }

    initTimer(): void {
        var refresh = timer(1000, 2000);
        refresh.subscribe(s => this.reloadMeet()); //TODO: Unsubcribe!
    }

    async reloadMeet(): Promise<void> {
        this.state.currentMeet = await this.meetApiClient.loadMeet(this.state.meetSettings.inviteHash);
    }

    checkIsMeetOpened(): void {
        if (!this.state.currentMeet) {
            this.router.navigate(['']);
        }
    }
}
