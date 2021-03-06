import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SpaSettings } from '../models/spa-settings';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
    private configuration: SpaSettings;
    constructor(private http: HttpClient) { }

  public async loadConfig(): Promise<void> {
        this.configuration = await this.http.get<SpaSettings>('/api/configuration/get')
            .toPromise();
    }

    public get meetApiUrl() {
        return this.configuration.meetApiUrl;
    }

    public get ssoApiUrl() {
        return this.configuration.ssoApiUrl;
    }

    public get baseInviteUrl() {
        return this.configuration.baseInviteUrl;
    }
}
