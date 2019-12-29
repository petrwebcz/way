import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InviteUrlComponent } from './invite-url/invite-url.component';
import { NicknameComponent } from './nickname/nickname.component';
import { MeetComponent } from './meet/meet.component';
import { FormsModule } from "@angular/forms";
import { OpenComponent } from './open/open.component';
import { AgmCoreModule } from '@agm/core';
import { ConfigurationService } from './services/configuration.service';
import { StateService } from './services/state.service';

const configInitializerFn = (spaConfig: ConfigurationService) => {
    return async () => {
        return await spaConfig.loadConfig();
    };
};

//const stateInitializerFn = (spaConfig: ConfigurationService) => {
//    return async () => {
//        return await spaConfig.loadConfig();
//    };
//};

@NgModule({
    declarations: [
        AppComponent,
        InviteUrlComponent,
        NicknameComponent,
        MeetComponent,
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
            useFactory: configInitializerFn,
            multi: true,
            deps: [ConfigurationService]
        }
        //StateService, {
        //    provide: APP_INITIALIZER,
        //    useFactory: stateInitializerFn,
        //    multi: true,
        //    deps: [StateService]
        //}
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }
