import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
import { ConfigurationService } from '../services/configuration.service';
import { ClipboardService } from 'ngx-clipboard';
import { AppComponent } from '../app.component';
import { ErrorType } from '../models/error-type';
import { EnterTheMeet } from '../models/enter-the-meet';

@Component({
  selector: 'app-invite-url',
  templateUrl: './invite-url.component.html',
  styleUrls: ['./invite-url.component.css'],
})

export class InviteUrlComponent implements OnInit, AfterViewInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    public state: StateService,
    private meetApiClient: MeetApiClientService,
    private router: Router,
    private configuration: ConfigurationService,
    private appComponent: AppComponent,
    private clipboardService: ClipboardService) { }

  ngOnInit(): void {
    this.initWizard();
  }

  ngAfterViewInit(): void {
  }

  copyInviteUrl() {
    if (!this.state.meetSettings.inviteUrl)
      return;

    this.clipboardService.copyFromContent(this.state.meetSettings.inviteUrl);

    this.appComponent.dialogOk("Odkaz zkopírován", "Pošlete ho přátelům sms zprávou či skrze libovolnou platformu a sejděte se na WAY.");
  }

  async generateMeet(): Promise<void> {
    try {
      let result = await this.meetApiClient.generateMeet();
      this.state.meetSettings.inviteHash = result.inviteHash;
      this.state.meetSettings.inviteUrl = result.inviteUrl;
    }

    catch (error) {
      this.appComponent.dialogError("Nepodařilo se vygenerovat setkání, zkuste to prosím později.", ErrorType.Error);
    }
  }

  initWizard(): void {
    if (this.activatedRoute.snapshot.params.inviteHash) {
      this.state.meetSettings = new EnterTheMeet({
        inviteHash: this.activatedRoute.snapshot.params.inviteHash,
        inviteUrl: this.configuration.baseInviteUrl.concat(this.activatedRoute.snapshot.params.inviteHash)
      });
    }

    else {
      this.state.meetSettings = new EnterTheMeet();
    }
  }
}
