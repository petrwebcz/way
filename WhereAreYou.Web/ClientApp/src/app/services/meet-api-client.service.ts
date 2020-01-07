import { Injectable, AfterViewInit } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from './state.service';
import { CreatedMeet } from '../models/created-meet';
import { CreateMeet } from '../models/create-meet';
import { Meet } from '../models/meet';
import { Location } from '../models/location';
import { Observable } from 'rxjs';
import { ConfigurationService } from './configuration.service';
import { MeetResponse } from '../models/meet-response';
import { AppComponent } from '../app.component';

@Injectable({
    providedIn: 'root'
})

export class MeetApiClientService {
    constructor(
        public state: StateService,
        private client: HttpClient,
        private configuration: ConfigurationService
    ) { }

    async generateMeet(): Promise<CreatedMeet> {
        let newMeet = new CreateMeet({
            name: new Date().toTimeString()
        });

        let url = this.urlBuilder("meet/create");
        let headers = this.headerBuilder();
        return await this.client.post<CreatedMeet>(url, newMeet, { headers: headers }).toPromise();
    }

    async loadMeet(inviteHash: string): Promise<MeetResponse> {
        let url = this.urlBuilder('meet/get');
        let headers = this.headerBuilder();
        return await this.client.get<MeetResponse>(url, { headers: headers }).toPromise();
    }

    async addPosition(location: Location): Promise<void> {
        let url = this.urlBuilder("meet/position/add");
        let headers = this.headerBuilder();
        await this.client.post(url, { location: location }, { headers: headers }).toPromise();
    }

    async updatePosition(location: Location): Promise<void> {
        let url = this.urlBuilder("meet/position/update");
        let headers = this.headerBuilder();
        await this.client.put(url, { location: location }, { headers: headers }).toPromise();
    }

    urlBuilder(path): string {
        console.log("urlbuilder");
        console.log(this.configuration);
        return this.configuration.meetApiUrl.concat(path);
    }

    headerBuilder(): HttpHeaders {
        let headers = new HttpHeaders()
            .append('Content-Type', 'application/json')
            .append('Accept', 'application/json');

        let token = localStorage.getItem("access-token");

        if (token != null)
            headers = headers
                .append('Authorization', token);

        console.log(headers);
        return headers;
    }
}
