import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
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
        private meetApiClient: MeetApiClientService,  
        private router: Router,
        private configuration: ConfigurationService) { }

    ngOnInit(): void {

    }

    ngAfterViewInit(): void {
        this.state.ResetForms();
        this.assignParams();
    }

    async generateMeet(): Promise<void> {
        let result = await this.meetApiClient.generateMeet();
        this.state.meetSettings.inviteHash = result.inviteHash;
        this.state.meetSettings.inviteUrl = result.inviteUrl;
    }

    assignParams() {
        this.state.meetSettings.inviteHash = this.route.snapshot.params.inviteHash;
        this.state.meetSettings.inviteUrl = this.configuration.baseInviteUrl
            .concat(this.state.meetSettings.inviteHash);
    }
}
