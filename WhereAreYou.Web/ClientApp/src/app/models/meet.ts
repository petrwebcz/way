import { Position } from './position';
import { Location } from './location';

export class Meet {
    id: string;
    name: string;
    created: string;
    lastUpdated: string;
    positions: Position[];
    inviteUrl: string;
    inviteHash: string;
    centerPoint: Location;

    public constructor(init?: Partial<Meet>) {
        Object.assign(this, init);
    }
}
