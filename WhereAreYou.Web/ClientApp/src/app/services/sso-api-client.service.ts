import { Injectable } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from './state.service';
import { EnterTheRoom } from '../models/enter-the-room';
import { Token } from '../models/token';
import { Observable } from 'rxjs';
import { ConfigurationService } from './configuration.service';
@Injectable({
    providedIn: 'root'
})

export class SsoApiClientService {
    private configuration: ConfigurationService;
    public headers: HttpHeaders;

    constructor(public state: StateService, public client: HttpClient) {
        this.headers = this.headerBudilder();
    }

    async enterTheRoom(model: EnterTheRoom): Promise<void> {
        let url = this.urlBuilder("sso/enterTheRoom");
        let response = await this.client.post<Token>(url, model, { headers: this.headers }).toPromise();
        var token = await response.jwt;
        localStorage.setItem("access-token", "bearer ".concat(response.jwt));
    }

    urlBuilder(path) {
        return this.configuration.ssoApiUrl.concat(path);
    }

    headerBudilder() {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        return headers;
    }
}
