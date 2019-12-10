import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { StateService } from '../state.service';
import { Observable } from 'rxjs';
import { FormsModule } from "@angular/forms";

@Component({
    selector: 'app-invite-url',
    templateUrl: './invite-url.component.html',
    styleUrls: ['./invite-url.component.css'],
})

export class InviteUrlComponent implements OnInit {
    state: StateService;
    constructor(private route: ActivatedRoute, private stateService: StateService, private http: HttpClientModule) {
        this.state = stateService;
    }

    async ngOnInit() {
        await this.bindServerInvite();
    }

    async bindServerInvite() {
        var params = await this.route.params.toPromise();
        this.state.inviteHash = params["inviteHash"];
    }


}
