import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { RoomApiClientService } from 'src/app/services/room-api-client.service';

@Component({
    selector: 'app-invite-url',
    templateUrl: './invite-url.component.html',
    styleUrls: ['./invite-url.component.css'],
})

export class InviteUrlComponent implements OnInit {
    constructor(private route: ActivatedRoute, public state: StateService, private roomApiClient: RoomApiClientService) { }

    async ngOnInit() {
        await this.state.ResetForms();
        await this.assignParams();
    }

    async generateRoom() {
        let result = await this.roomApiClient.generateRoom();
        this.state.roomSettings.inviteHash = result.inviteHash;
        this.state.roomSettings.inviteUrl = result.inviteUrl;
    }

    async assignParams() {
        var params = await this.route.params.toPromise();
        this.state.roomSettings.inviteHash = params["inviteHash"];
    }
}
