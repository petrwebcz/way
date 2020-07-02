import { Position } from './position';
import { Location } from './location';
import { UserPosition } from './user-position';

export class Meet {
  id: string;
  name: string;
  created: string;
  lastUpdated: string;
  positions: UserPosition[]; //TODO: Change to Position.
  inviteUrl: string;
  inviteHash: string;
  centerPoint: Location;

  public constructor(init?: Partial<Meet>) {
    Object.assign(this, init);
  }
}
