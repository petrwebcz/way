import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler, APP_INITIALIZER } from '@angular/core';
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
import { ClipboardModule } from 'ngx-clipboard';

const configInitializerFn = (spaConfig: ConfigurationService) => {
    return async () => {
        return await spaConfig.loadConfig();
    };
};

export class MyErrorHandler implements ErrorHandler {
    constructor() {
    }

    handleError(error: Error) {
        if (Error) {
            console.log(error.message);
            alert(error.message);
        }

        else
            console.log("Unhandled error with null Error");
    }
}

@NgModule({
    declarations: [
        AppComponent,
        InviteUrlComponent,
        NicknameComponent,
        MeetComponent,
        OpenComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ClipboardModule,
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
        },
        {
            provide: ErrorHandler,
            useClass: MyErrorHandler,
        }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
