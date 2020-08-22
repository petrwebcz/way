import { Injectable } from '@angular/core';
import { Token } from '../models/token';
import { UserData } from '../models/user-data';

@Injectable({
  providedIn: 'root'
})

export class TokenStorageServiceService { //TODO: Rename

  constructor() {
  }

  public insertToken(inviteHash: string, token: Token): void {
    localStorage.setItem(inviteHash, token.jwt);
  }

  public getToken(inviteHash: string): Token {
    let jwt = localStorage.getItem(inviteHash);
    if (jwt) {
      var token = new Token({
        jwt: jwt
      });
      return token;
    }
  }
}
