import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StateService } from '../services/state.service';

@Component({
  selector: 'app-nickname',
  templateUrl: './nickname.component.html',
  styleUrls: ['./nickname.component.css']
})
export class NicknameComponent implements OnInit {
  inviteHash: any;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    public stateService: StateService,
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.inviteHash = params["inviteHash"];
      if (!this.inviteHash) {
        throw new Error("Invite hash route parameter is not defined.");
      }
    });
  }

  onKeydown(event) {
    if (event.key === "Enter") {
      this.redirectToOpenMeet();
    }
  }

  redirectToOpenMeet(): void {
    let url = '/invite/' + this.inviteHash + '/open';
    this.router.navigate([url]);
  }
}
