import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Routes, Router, RouterModule } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { RoomApiClientService } from 'src/app/services/room-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';

@Component({
    selector: 'app-open',
    templateUrl: './open.component.html',
    styleUrls: ['./open.component.css']
})
export class OpenComponent implements OnInit, AfterViewInit {

    public message: string = "Vaše setkání se připravuje.";
    constructor(
        private state: StateService,
        private roomApiClient: RoomApiClientService,
        private ssoApiClient: SsoApiClientService,
        private router: Router) { }

    async ngOnInit() {
         
    }

    async  ngAfterViewInit(): Promise<void> {
        this.OpenRoom()
            .then(this.redirectToRoom)
            .catch(console.log);
    }

    async OpenRoom(): Promise<void> {
        var model = this.state.roomSettings;
        await this.ssoApiClient.enterTheRoom(model);
        this.state.currentRoom = await this.roomApiClient.loadRoom(model.inviteHash);
        this.redirectToRoom();
    }

    redirectToRoom(): void {
        this.router.navigate(['room']);
    }

    errorHandle(e): void {
        console.log(e);
        this.message = "Nepodařio se otevřít setkání. Zkuste to prosím znovu, případně si vytvořte nové.";
    }

}
