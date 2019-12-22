import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InviteUrlComponent } from './invite-url/invite-url.component';
import { NicknameComponent } from './nickname/nickname.component';
import { RoomComponent } from './room/room.component';
import { FormsModule } from "@angular/forms";
import { OpenComponent } from './open/open.component';
import { AgmCoreModule } from '@agm/core';
import { ConfigurationService } from './services/configuration.service';

const appInitializerFn = (spaConfig: ConfigurationService) => {
    return async () => {
        return await spaConfig.loadConfig();
    };
};

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
        AgmCoreModule.forRoot({
            apiKey: '-'
        })

    ],
    providers: [
        ConfigurationService,
        {
            provide: APP_INITIALIZER,
            useFactory: appInitializerFn,
            multi: true,
            deps: [ConfigurationService]
        }],
    bootstrap: [AppComponent]
})

export class AppModule { }
