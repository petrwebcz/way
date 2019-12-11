import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { StateService } from 'src/app/services/state.service';
import { CreatedRoom } from '../models/created-room';
import { CreateRoom } from '../models/create-room';
import { Room } from '../models/room';

@Injectable({
    providedIn: 'root'
})

export class RoomApiClientService {
    constructor(public state: StateService, public client: HttpClient) { }

    async generateRoom(): Promise<CreatedRoom> {
        let newRoom = new CreateRoom({
            name: new Date().toTimeString()
        });

        let result = this.client.post<CreatedRoom>("/room/create", newRoom);
        return result.toPromise();
    }

    async pushLocation(location: Location): Promise<void> {
        await this.client.put("/room/position/update", location);
    }

    async loadRoom(inviteHash: string): Promise<Room> {
        let path = '/room/' + inviteHash;
        let result = await this.client.get<Room>(path);
        return result.toPromise();
    }
}
