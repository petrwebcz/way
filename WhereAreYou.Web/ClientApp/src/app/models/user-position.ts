import { User } from './user';
import { Location } from './location';
import { Position } from './position';

export class UserPosition extends Position {
  user: User;

  constructor(init?: Partial<UserPosition>) {
    super({
      location: init.location
    });

    this.user = init.user;
  }
}
