import { Component, OnInit } from '@angular/core';
import { StateService } from 'src/app/state.service';

@Component({
    selector: 'app-room',
    templateUrl: './room.component.html',
    styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {

    constructor(private stateService: StateService) {
        this.stateService = stateService;
    }

    ngOnInit() {
    }
}
