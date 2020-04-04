import { Injectable } from '@angular/core';
import { HttpClientModule, HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { EnterTheMeet } from '../models/enter-the-meet';
import { Token } from '../models/token';
import { Observable } from 'rxjs';
import { ConfigurationService } from './configuration.service';
@Injectable({
  providedIn: 'root'
})

export class SsoApiClientService {
  public headers: HttpHeaders;

  constructor(
    public client: HttpClient,
    private configuration: ConfigurationService) {
    this.headers = this.headerBudilder();
  }

  async enterTheMeet(model: EnterTheMeet): Promise<void> {
    let url = this.urlBuilder("sso/enterTheMeet");
    let response = await this.client.post<Token>(url, model, { headers: this.headers }).toPromise();
    var token = await response.jwt;

    localStorage.setItem("access-token", "bearer ".concat(response.jwt));
  }

  urlBuilder(path) {
    return this.configuration.ssoApiUrl.concat(path);
  }

  headerBudilder() {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');

    return headers;
  }
}
