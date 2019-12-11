import { Component, OnInit } from '@angular/core';
import { Routes, Router, RouterModule } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { RoomApiClientService } from 'src/app/services/room-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';

@Component({
    selector: 'app-open',
    templateUrl: './open.component.html',
    styleUrls: ['./open.component.css']
})
export class OpenComponent implements OnInit {
    message: string = "Vaše setkání se připravuje.";
    constructor(
        private state: StateService,
        private roomApiClient: RoomApiClientService,
        private ssoApiClient: SsoApiClientService,
        private router: Router) { }

    async ngOnInit() {
        try {
            var model = this.state.roomSettings;
            //await this.ssoApiClient.enterTheRoom(model);

            //this.state.currentRoom = await this.roomApiClient.loadRoom(model.inviteHash);
            await this.Delay(3000);
            await this.OpenRoom();
        }

        catch (e) {
            this.message = "Nepodařio se otevřít setkání. Zkuste to prosím znovu, případně si vytvořte nové.";
            console.log(e);
        }
    }

    async OpenRoom() {
        this.router.navigate(['room']);
    }

    async Delay(ms: number) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
}
