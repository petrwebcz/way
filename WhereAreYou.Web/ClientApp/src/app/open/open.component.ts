import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Routes, Router, RouterModule } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
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
        private meetApiClient: MeetApiClientService,
        private ssoApiClient: SsoApiClientService,
        private router: Router) { }

    async ngOnInit() {
         
    }

    async ngAfterViewInit(): Promise<void> {
        this.OpenMeet()
            .then(this.redirectToMeet)
            .catch(console.log);
    }

    async OpenMeet(): Promise<void> {
        var model = this.state.meetSettings;
        await this.ssoApiClient.enterTheMeet(model);
        this.state.currentMeet = await this.meetApiClient.loadMeet(model.inviteHash);
        this.redirectToMeet();
    }

    redirectToMeet(): void {
        this.router.navigate(['meet']);
    }

    errorHandle(e): void {
        console.log(e);
        this.message = "Nepodařio se otevřít setkání. Zkuste to prosím znovu, případně si vytvořte nové.";
    }

}
