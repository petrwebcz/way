import { Injectable, AfterViewInit } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from 'src/app/services/state.service';
import { CreatedRoom } from '../models/created-room';
import { CreateRoom } from '../models/create-room';
import { Room } from '../models/room';
import { Location } from '../models/location';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class RoomApiClientService {
    public baseUrl: string = 'https://api.petrweb.cz/api/';
  
    constructor(public state: StateService, public client: HttpClient) { }

    async generateRoom(): Promise<CreatedRoom> {
        let newRoom = new CreateRoom({
            name: new Date().toTimeString()
        });

        let url = this.urlBuilder("room/create");
        let headers = this.headerBuilder();
        return await this.client.post<CreatedRoom>(url, newRoom, { headers: headers }).toPromise();
    }

    async pushLocation(location: Location): Promise<void> {
        let url = this.urlBuilder("room/position/update");
        let headers = this.headerBuilder();
        await this.client.put(url, { location: location }, { headers: headers }).toPromise();
    }

    async loadRoom(inviteHash: string): Promise<Room> {
        let url = this.urlBuilder('room');
        let headers = this.headerBuilder();
        return await this.client.get<Room>(url, { headers: headers }).toPromise();
    }

    urlBuilder(path): string {
        return this.baseUrl.concat(path);
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
