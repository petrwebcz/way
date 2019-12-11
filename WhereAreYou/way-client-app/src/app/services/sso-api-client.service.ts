import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from 'src/app/services/state.service';
import { EnterTheRoom } from '../models/enter-the-room';

@Injectable({
    providedIn: 'root'
})

export class SsoApiClientService {
    constructor(public state: StateService, public client: HttpClient) { }

    async enterTheRoom(model: EnterTheRoom): Promise<void> {
        let result = await this.client.post("/sso/enter/enterTheRoom", model);
        let token = await result.source.toPromise();
        localStorage.setItem("access-token", token);
    }
}
