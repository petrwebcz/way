import { UserData } from "./user-data";
import * as jwt_decode from "jwt-decode";

export class Token {
  jwt: string;

  public constructor(init?: Partial<Token>) {
    Object.assign(this, init);
  }

  public get userData(): UserData {
    var decoded = jwt_decode(this.jwt)

    if (!decoded) {
      throw new Error("Error in decode jwt token");
    }

    var userDataJson = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata"]
    var userData: UserData = JSON.parse(userDataJson);

    return userData;
  }
}

