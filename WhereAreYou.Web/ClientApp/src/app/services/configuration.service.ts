import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SpaSettings } from '../models/spa-settings';
@Injectable()
export class ConfigurationService {
    private configuration: SpaSettings;
    constructor(private http: HttpClient) { }

    public async loadConfig():Promise<void> {
        this.configuration = await this.http.get<SpaSettings>('/api/configuration/get')
            .toPromise();
    }

    get roomApiUrl() {
        return this.configuration.RoomApiUrl;
    }

    get ssoApiUrl() {
        return this.configuration.SsoApiUrl;
    }
}
