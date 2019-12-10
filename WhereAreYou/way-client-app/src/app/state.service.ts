import { Injectable } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
@Injectable({
    providedIn: 'root'
})
export class StateService {
    public currentPanel: string;
    public inviteHash: string;
    public inviteUrl: string;
    public nickname: string;
    constructor() {
    }

}
