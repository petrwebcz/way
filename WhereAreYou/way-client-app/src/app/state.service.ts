import { Injectable } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";
@Injectable({
    providedIn: 'root'
})
export class StateService {
    openRoom() {
        throw new Error("Method not implemented.");
    }
    public currentPanel: string;
    public inviteHash: string;
    public inviteUrl: string = "Frontend aplikace je zatím ve vývoji a neni plně funkční :-) www.petrweb.cz";
    public nickname: string;
    constructor() {
    }

}
