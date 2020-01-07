import { Component } from '@angular/core';
import { OkDialogComponent } from './ok-dialog/ok-dialog.component';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { setTheme } from 'ngx-bootstrap/utils';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ErrorDialogComponent } from './error-dialog/error-dialog.component';
import { ErrorResponse } from './models/error-response';
import { ErrorType } from './models/error-type';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    title = 'WAY - vytvoř setkání a pošli svou polohu odkazem';

    constructor(
        private modalService: BsModalService,
        private modalRef: BsModalRef) {
        setTheme('bs4');
    }

    dialogOk(header: string, message: string) {
        this.modalRef = this.modalService.show(OkDialogComponent, {
            initialState: {
                header: header,
                message: message
            }
        });
    }

    dialogErrorResponse(error: ErrorResponse) {
        this.closeAllModals();
        this.modalRef = this.modalService.show(ErrorDialogComponent, {
            initialState: {
                error: error
            }
        });
    }

    dialogError(message: string, errorType: ErrorType) {
        this.closeAllModals();
        this.modalRef = this.modalService.show(ErrorDialogComponent, {
            initialState: {
                error: new ErrorResponse({
                    errorType: errorType,
                    errorMessage: message
                })
            }
        });
    }

    closeAllModals() {
        for (let i = 1; i <= this.modalService.getModalsCount(); i++) {
            this.modalService.hide(i);
        }
    }
}
