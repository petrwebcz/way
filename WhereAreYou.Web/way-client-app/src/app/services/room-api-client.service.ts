import { Injectable, AfterViewInit } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from 'src/app/services/state.service';
import { CreatedRoom } from '../models/created-room';
import { CreateRoom } from '../models/create-room';
import { Room } from '../models/room';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class RoomApiClientService {
    public baseUrl: string = 'http://api.petrweb.local/api/';

    get headers(): HttpHeaders {
        return this.headerBuilder();
    }

    constructor(public state: StateService, public client: HttpClient) {
    }

    async generateRoom(): Promise<CreatedRoom> {
        let newRoom = new CreateRoom({
            name: new Date().toTimeString()
        });

        let url = this.urlBuilder("room/create");
        let result = this.client.post<CreatedRoom>(url, newRoom, { headers: this.headers }).toPromise();

        return result;
    }

    async pushLocation(location: Location): Promise<void> {
        await this.client.put("room/position/update", location, { headers: this.headers }).toPromise();
    }

    async loadRoom(inviteHash: string): Promise<Room> {
        var self = this;
        let path = 'room';
        var url = this.baseUrl.concat(path);

        let token = localStorage.getItem("access-token");

        let headers = new HttpHeaders();
        headers = headers.append('Authorization', token);
        headers = headers.append('Content-Type', 'application/json');
        let result = await this.client.get<Room>(url, { headers }).toPromise();

        return result;
    }

    urlBuilder(path): string {
        return this.baseUrl.concat(path);
    }

    headerBuilder(): HttpHeaders {
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');

        let token = localStorage.getItem("access-token");

        if (token != null) {
            headers.append('Authorization', token);
        }

        return headers;
    }
}
