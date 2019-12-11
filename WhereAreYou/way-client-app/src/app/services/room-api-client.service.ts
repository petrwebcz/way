import { Injectable } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
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

export class RoomApiClientService implements HttpInterceptor {
    public baseUrl: string = 'http://api.petrweb.local/api/';
    constructor(public state: StateService, public client: HttpClient) { }

    async generateRoom(): Promise<CreatedRoom> {
        let newRoom = new CreateRoom({
            name: new Date().toTimeString()
        });

        let url = this.urlBuilder("room/create");
        console.log(url);
        let result = this.client.post<CreatedRoom>(url, newRoom);
        return result.toPromise();
    }

    async pushLocation(location: Location): Promise<void> {
        await this.client.put("room/position/update", location);
    }

    async loadRoom(inviteHash: string): Promise<Room> {
        let path = 'room/' + inviteHash;
        let result = await this.client.get<Room>(path);
        return result.toPromise();
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var token = localStorage.getItem("access-token");
        if (token == null)
            return;

        const authReq = req.clone({ setHeaders: { Authorization: token } });
        return next.handle(authReq);
    }

    urlBuilder(path) {
        return this.baseUrl.concat(path);
    }
}
