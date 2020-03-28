import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Routes, Router, RouterModule } from '@angular/router';
import { StateService } from 'src/app/services/state.service';
import { MeetApiClientService } from 'src/app/services/meet-api-client.service';
import { SsoApiClientService } from 'src/app/services/sso-api-client.service';
import { AppComponent } from '../app.component';
import { ErrorType } from '../models/error-type';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorResponse } from '../models/error-response';

@Component({
  selector: 'app-open',
  templateUrl: './open.component.html',
  styleUrls: ['./open.component.css']
})
export class OpenComponent implements OnInit, AfterViewInit {
  public message: string = "Vaše setkání se připravuje.";
  constructor(
    private state: StateService,
    private meetApiClient: MeetApiClientService,
    private ssoApiClient: SsoApiClientService,
    private appComponent: AppComponent,
    private router: Router) { }

  async ngOnInit() {

  }

  async ngAfterViewInit(): Promise<void> {
    await this.OpenMeet();
  }

  async OpenMeet(): Promise<void> {
    try {

      var model = this.state.meetSettings;

      await this.ssoApiClient.enterTheMeet(model);

      this.state.currentMeet = await this.meetApiClient.loadMeet(model.inviteHash);

      this.redirectToMeet();
    }

    catch (error) {

      if (error.error && error.error instanceof ErrorResponse)
        this.appComponent.dialogErrorResponse(error.error);

      else
        this.appComponent.dialogError("Nepodařio se otevřít setkání pravděpdoboně z důvodů problémů na straně síťového připojení. Zkuste to prosím znovu, případně si vytvořte nové.", ErrorType.Error);
    }
  }

  redirectToMeet(): void {
    this.router.navigate(['meet']);
  }

  errorHandle(e): void {
    console.log(e);
    this.message = "Nepodařio se otevřít setkání. Zkuste to prosím znovu, případně si vytvořte nové.";
  }

}
