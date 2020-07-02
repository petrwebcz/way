import { Position } from './position';
import { Location } from './location';
import { Meet } from './meet';
import { UserPosition } from './user-position';

export class MeetResponse {
  meet: Meet;
  users: UserPosition[];
  currentUser: UserPosition;
  centerPoint: Location;
  zoomLevel: number;

  constructor() {
    this.currentUser = new UserPosition();
    this.centerPoint = new Location();
    this.users = new Array<UserPosition>(); //TODO: Change to Position
  }
}

