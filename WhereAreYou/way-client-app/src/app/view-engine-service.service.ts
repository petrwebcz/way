import { Injectable } from '@angular/core';
import { Routes, RouterModule, Router, ActivatedRoute } from "@angular/router";

@Injectable({
  providedIn: 'root'
})

export class ViewEngineServiceService {
    currentPanel: string;
    inviteHash: string;
    constructor() { }
}
