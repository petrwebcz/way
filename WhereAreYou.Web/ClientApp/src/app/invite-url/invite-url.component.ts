import { Component, OnInit, AfterViewInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MeetApiClientService } from '../services/meet-api-client.service';
import { StateService } from '../services/state.service';
import { ClipboardService } from 'ngx-clipboard';
import { AppComponent } from '../app.component';
import { ErrorType } from '../models/error-type';
import { EnterTheMeet } from '../models/enter-the-meet';
import { ConfigurationService } from '../services/configuration.service';

@Component({
  selector: 'app-invite-url',
  templateUrl: './invite-url.component.html',
  styleUrls: ['./invite-url.component.css'],
})

export class InviteUrlComponent implements OnInit, AfterViewInit {
  inviteHash: any;
  constructor(
    private meetApiClient: MeetApiClientService,
    private router: Router,
    private appComponent: AppComponent,
    private clipboardService: ClipboardService,
    private activatedRoute: ActivatedRoute,
    private configurationService: ConfigurationService,
    public stateService: StateService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.inviteHash = params["inviteHash"];

      if (this.inviteHash) {
        this.stateService.enterTheMeet = new EnterTheMeet({
          inviteHash: this.inviteHash,
          inviteUrl: this.configurationService.baseInviteUrl.concat(this.activatedRoute.snapshot.params.inviteHash)
        });
      }
      else {
        this.stateService.enterTheMeet = new EnterTheMeet()
      }
    })
  }

  ngAfterViewInit(): void {
  }

  copyInviteUrl() {
    if (!this.stateService.enterTheMeet.inviteUrl) {
      return;
    }

    this.clipboardService.copyFromContent(this.stateService.enterTheMeet.inviteUrl);
    this.appComponent.dialogOk("Odkaz zkopírován", "Pošlete ho přátelům sms zprávou či skrze libovolnou platformu a sejděte se na WAY.");
  }

  async generateMeet(): Promise<void> {
    try {
      let result = await this.meetApiClient.generateMeet();
      this.router.navigate(['/invite', result.inviteHash]);
    }

    catch (error) {
      this.appComponent.dialogError("Nepodařilo se vygenerovat setkání, zkuste to prosím později.", ErrorType.Error);
    }
  }
}
