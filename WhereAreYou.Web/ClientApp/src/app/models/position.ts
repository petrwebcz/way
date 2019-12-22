import { User } from './user';
import { Location } from './location';

export class Position {
    user: User;
    location: Location;

    public constructor(init?: Partial<Position>) {
        Object.assign(this, init);
    }
}
