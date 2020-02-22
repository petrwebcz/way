import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler, APP_INITIALIZER, Injector } from '@angular/core';
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
import { OkDialogComponent } from './ok-dialog/ok-dialog.component';
import { ModalModule, BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ErrorDialogComponent } from './error-dialog/error-dialog.component';
import { ErrorType } from './models/error-type';
import { ErrorResponse } from './models/error-response';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertModule } from 'ngx-bootstrap';
import { UsersDialogComponent } from './users-dialog/users-dialog.component';

const configInitializerFn = (spaConfig: ConfigurationService) => {
    return async () => {
        return await spaConfig.loadConfig();
    };
};

export class MyErrorHandler implements ErrorHandler {
    modalRef: BsModalRef;
    modalService: BsModalService;
    errors: number = 0;

    constructor(
      /*  private modalService: BsModalService*/) {
    }

    handleError(error: Error) {
        if (!Error)
            return;

        if (this.errors === 0)
            alert("V aplikaci se vyskytla kritická chyba (" + error.message + " ), bude restartována. ");

        this.errors++;
        console.log(error);
    }

    dialogError(message: string, errorType: ErrorType) {
        this.modalRef = this.modalService.show(ErrorDialogComponent, {
            class: 'modal-sm',
            initialState: {
                error: new ErrorResponse({
                    errorType: ErrorType.Error,
                    errorMessage: message
                })
            }
        });
    }
}

@NgModule({
    declarations: [
        AppComponent,
        InviteUrlComponent,
        NicknameComponent,
        MeetComponent,
        OpenComponent,
        OkDialogComponent,
        ErrorDialogComponent,
        UsersDialogComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ClipboardModule,
        ModalModule.forRoot(),
        AlertModule.forRoot(),
        AgmCoreModule.forRoot({
            apiKey: '-'
        }),
        BrowserAnimationsModule,
    ],
    entryComponents: [
        OkDialogComponent,
        ErrorDialogComponent,
        UsersDialogComponent
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
            useClass: MyErrorHandler
            //deps: [BsModalService]
        },
        BsModalRef
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
