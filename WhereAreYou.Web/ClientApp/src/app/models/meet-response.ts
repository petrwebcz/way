import { Position } from './position';
import { Location } from './location';
import { Meet } from './meet';

export class MeetResponse {
  meet: Meet;
  users: Position[];
  currentUser: Position;
  centerPoint: Location;
  zoomLevel: number;

  constructor() {
    this.currentUser = new Position();
    this.centerPoint = new Location();
    this.users = new Array<Position>();
  }
}

