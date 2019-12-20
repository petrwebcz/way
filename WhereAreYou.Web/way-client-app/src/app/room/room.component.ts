import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { RoomApiClientService } from 'src/app/services/room-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';
import { AgmCoreModule } from '@agm/core';
import { Location } from '../models/location';
import { Routes, Router, RouterModule } from '@angular/router';
import { timer } from 'rxjs';

@Component({
    selector: 'app-room',
    templateUrl: './room.component.html',
    styleUrls: ['./room.component.css']
})

export class RoomComponent implements OnInit, AfterViewInit, OnDestroy {
    constructor(
        private state: StateService,
        public roomApiClient: RoomApiClientService,
        private ssoApiClient: SsoApiClientService,
        private router: Router) { }


    ngOnInit(): void {
        this.checkIsRoomOpened();
    }

    ngAfterViewInit(): void {
        this.initTimer();
        this.initTracker();
    }

    ngOnDestroy(): void {

    }

    initTracker(): void {
        this.roomApiClient.pushLocation({ latitude: 1, longitude: 2 });
        if ('geolocation' in navigator === false) {
            console.log("Only view mode");
            return;
        }

        navigator.geolocation.watchPosition((f) => this.roomApiClient.pushLocation(f.coords), (err) => console.log(err), {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        });
    }

    initTimer(): void {
        var refresh = timer(1000, 2000);
        refresh.subscribe(s => this.reloadRoom()); //TODO: Unsubcribe!
    }


    async reloadRoom() {
        console.log("reloading room");
        this.state.currentRoom = await this.roomApiClient.loadRoom(this.state.roomSettings.inviteHash);
    }

    checkIsRoomOpened(): void {
        if (!this.state.currentRoom) {
            this.router.navigate(['']);
        }
    }
}
