import { Component, OnInit, AfterViewInit, Inject } from '@angular/core';
import { Router, RouterModule, ActivatedRoute } from '@angular/router';
import { SsoApiClientService } from './../services/sso-api-client.service';
import { AppComponent } from '../app.component';
import { ErrorType } from '../models/error-type';
import { ErrorResponse } from '../models/error-response';
import { StateService } from '../services/state.service';
import { TokenStorageServiceService } from '../services/token-storage-service.service';

@Component({
  selector: 'app-open',
  templateUrl: './open.component.html',
  styleUrls: ['./open.component.css']
})
export class OpenComponent implements OnInit, AfterViewInit {
  public message: string = "Vaše setkání se připravuje.";
  inviteHash: any;
  constructor(
    private ssoApiClient: SsoApiClientService,
    private appComponent: AppComponent,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private tokenStorageService: TokenStorageServiceService,
    public stateService: StateService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.inviteHash = params["inviteHash"];
      if (!this.inviteHash) {
        throw new Error("Invite hash route parameter is not defined.");
      }
    });
  }

  async ngAfterViewInit(): Promise<void> {
    await this.OpenMeet();
  }

  async OpenMeet(): Promise<void> {
    try {
      let token = await this.ssoApiClient.enterTheMeet(this.stateService.enterTheMeet);
      this.tokenStorageService.insertToken(this.inviteHash, token);
      this.redirectToMeet();
    }

    catch (error) {
      if (error.error && error.error instanceof ErrorResponse) {
        this.appComponent.dialogErrorResponse(error.error);
      }

      else {
        this.appComponent.dialogError("Nepodařio se otevřít setkání pravděpdoboně z důvodů problémů na straně síťového připojení. Zkuste to prosím znovu, případně si vytvořte nové.", ErrorType.Error);
      }
    }
  }

  redirectToMeet(): void {
    this.router.navigate(['meet', this.inviteHash]);
  }

  errorHandle(e): void {
    this.message = "Nepodařio se otevřít setkání. Zkuste to prosím znovu, případně si vytvořte nové.";
  }
}
