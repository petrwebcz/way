import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { TokenStorageServiceService } from '../services/token-storage-service.service';
import { MeetApiClientService } from '../services/meet-api-client.service';
import { Token } from '../models/token';
import { MeetResponse } from '../models/meet-response';


@Component({
  selector: 'app-users-dialog',
  templateUrl: './users-dialog.component.html',
  styleUrls: ['./users-dialog.component.css']
})

export class UsersDialogComponent implements AfterViewInit {
  token: Token;
  public currentMeet: MeetResponse;
  inviteHash: any;
  constructor(
    private modalService: BsModalService,
    private modalRef: BsModalRef,
    private tokenStorageService: TokenStorageServiceService,
    private meetApiClientService: MeetApiClientService
  ) {
  }

  ngOnInit(): void {

  }

 async ngAfterViewInit(): Promise<void> {
    //this.currentMeet = await this.meetApiClientService.loadMeet(this.token.userData.meetInviteHash, this.token);
  }

  close(): void {
    this.modalRef.hide();
  }
}
