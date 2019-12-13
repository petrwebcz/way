import { User } from './user';

export class Position {
    user: User;
    location: Location;

    public constructor(init?: Partial<Position>) {
        Object.assign(this, init);
    }
}
