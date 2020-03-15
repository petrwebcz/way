import { Component, OnInit } from '@angular/core';
import { StateService } from '../services/state.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
    selector: 'app-users-dialog',
    templateUrl: './users-dialog.component.html',
    styleUrls: ['./users-dialog.component.css']
})

export class UsersDialogComponent implements OnInit {
    constructor(
        public state: StateService,
        private modalService: BsModalService,
        private modalRef: BsModalRef) {
    }

    ngOnInit(): void {

    }


    close(): void {
        this.modalRef.hide();
    }
}
