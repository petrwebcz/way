import { Location } from './location';

export class Position {
    location: Location;

    public constructor(init?: Partial<Position>) {
        Object.assign(this, init);
    }
}
