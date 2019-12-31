import { Position } from './position';
import { Location } from './location';
import { Meet } from './meet';

export class MeetResponse {
    meet: Meet;
    users: Position[];
    currentUser: Position;
    centerPoint: Location;
}
