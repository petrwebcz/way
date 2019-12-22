import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { RoomApiClientService } from 'src/app/services/room-api-client.service';
import { ConfigurationService } from '../services/configuration.service';

@Component({
    selector: 'app-invite-url',
    templateUrl: './invite-url.component.html',
    styleUrls: ['./invite-url.component.css'],
})

export class InviteUrlComponent implements OnInit, AfterViewInit {
    constructor(
        private route: ActivatedRoute,
        public state: StateService,
        private roomApiClient: RoomApiClientService,
        private router: Router,
        private configuration: ConfigurationService) { }

    ngOnInit(): void {

    }

    ngAfterViewInit(): void {
        this.state.ResetForms();
        this.assignParams();
    }

    async generateRoom(): Promise<void> {
        let result = await this.roomApiClient.generateRoom();
        this.state.roomSettings.inviteHash = result.inviteHash;
        this.state.roomSettings.inviteUrl = result.inviteUrl;
    }

    assignParams() {
        this.state.roomSettings.inviteHash = this.route.snapshot.params.inviteHash;
        this.state.roomSettings.inviteUrl = this.configuration.baseInviteUrl
            .concat(this.state.roomSettings.inviteHash);
    }
}
