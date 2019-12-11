import { Injectable } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from 'src/app/services/state.service';
import { EnterTheRoom } from '../models/enter-the-room';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class SsoApiClientService {
    public baseUrl: string = 'http://sso.petrweb.local/';
    constructor(public state: StateService, public client: HttpClient) { }

    async enterTheRoom(model: EnterTheRoom): Promise<void> {
        let url = this.urlBuilder("/sso/enterTheRoom");
        let result = await this.client.post(url, model);
        let token = await result.source.toPromise();

        localStorage.setItem("access-token", token);
    }

    urlBuilder(path) {
        return this.baseUrl.concat(path);
    }
}