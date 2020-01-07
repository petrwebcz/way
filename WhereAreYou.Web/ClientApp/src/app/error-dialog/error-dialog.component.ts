import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ErrorResponse } from '../models/error-response';
import { ValidationErrorItem } from '../models/validation-error-item';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { ErrorType } from '../models/error-type';

@Component({
    selector: 'app-error-dialog',
    templateUrl: './error-dialog.component.html',
    styleUrls: ['./error-dialog.component.css']
})

export class ErrorDialogComponent implements OnInit {
    error: ErrorResponse;

    get elementsVisible(): any {
        return {
            btn: {
                backToInvite: this.error.errorType == ErrorType.Validation,
                logout: this.error.errorType == ErrorType.Critical,
                close: this.error.errorType == ErrorType.Error
            },
            panel: {
                validation: this.error.errorType == ErrorType.Validation,
                error: this.error.errorType == ErrorType.Error,
                critical: this.error.errorType == ErrorType.Critical
            }
        }
    }

    constructor(
        private router: Router,
        private modalService: BsModalService,
        private modalRef: BsModalRef) {
    }

    ngOnInit(): void {
    }

    backToInvite(): void {
        this.router.navigate(['']);
    }

    close(): void {
        this.modalRef.hide();
    }

    logout(): void {

    }
}
