import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InviteUrlComponent } from './invite-url/invite-url.component';
import { NicknameComponent } from './nickname/nickname.component';
import { RoomComponent } from './room/room.component';
import { FormsModule } from "@angular/forms";
import { OpenComponent } from './open/open.component';

//import { EnterTheRoom } from './models/enter-the-room';
//import { CreateRoom } from './models/create-room';
//import { CreatedRoom } from './models/created-room';
//import { Room } from './models/room';

//import { User } from './models/user';
//import { Location } from './models/location';
//import { Position } from './models/position';
//import { UpdatePosition } from './models/update-position';

@NgModule({
    declarations: [
        AppComponent,
        InviteUrlComponent,
        NicknameComponent,
        RoomComponent,
        OpenComponent

    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
