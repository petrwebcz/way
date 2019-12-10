import { Component, OnInit } from '@angular/core';
import { StateService } from 'src/app/state.service';

@Component({
    selector: 'app-nickname',
    templateUrl: './nickname.component.html',
    styleUrls: ['./nickname.component.css']
})
export class NicknameComponent implements OnInit {

    state: StateService;
    constructor(stateService: StateService) {
        this.state = stateService;
    }

    ngOnInit() {
    }
}
