import { OnInit } from '@angular/core';
import { Component, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-ok-dialog',
    templateUrl: './ok-dialog.component.html',
    styleUrls: ['./ok-dialog.component.css']
})

export class OkDialogComponent implements OnInit {
    message: string;
    header: string;

    constructor(
        private modalRef: BsModalRef) {
    }

    ngOnInit(): void {

    }

    close(): void {
        this.modalRef.hide();
    }
}
