import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InviteUrlComponent } from './invite-url/invite-url.component';
import { NicknameComponent } from './nickname/nickname.component';
import { MeetComponent } from './meet/meet.component';
import { OpenComponent } from './open/open.component';
import { StateService } from './services/state.service';


const routes: Routes = [
    { path: '', component: InviteUrlComponent, pathMatch: 'full' },
    { path: 'meet/:inviteHash', component: InviteUrlComponent, pathMatch: 'prefix' },
    { path: 'select-nickname', component: NicknameComponent },
    { path: 'open', component: OpenComponent },
    { path: 'meet', component: MeetComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {
   
}
