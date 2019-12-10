import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InviteUrlComponent } from './invite-url/invite-url.component';
import { NicknameComponent } from './nickname/nickname.component';
import { RoomComponent } from './room/room.component';
import { MapComponent } from './map/map.component';
import { StateService } from './state.service';
import { OpenComponent } from './open/open.component';


const routes: Routes = [
    { path: '', component: InviteUrlComponent, pathMatch: 'full' },
    { path: 'meet/:inviteHash', component: InviteUrlComponent, pathMatch: 'prefix' },
    { path: 'select-nickname', component: NicknameComponent },
    { path: 'open', component: OpenComponent },
    { path: 'room', component: RoomComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {
   
}
