import { User } from "./user";

export class UserData {
  user: User;
  meetInviteHash: string;
  public constructor(init?: Partial<UserData>) {
    Object.assign(this, init);
  }
}
