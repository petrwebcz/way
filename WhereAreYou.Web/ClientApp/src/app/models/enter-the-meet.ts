import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class EnterTheMeet {
  nickname: string = "";
  inviteHash: string = "";
  inviteUrl: string = "";

  public constructor(init?: Partial<EnterTheMeet>) {
    Object.assign(this, init);
  }
}
