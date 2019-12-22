export class Location {
    latitude: number;
    longitude: number;

    public constructor(init?: Partial<Location>) {
        Object.assign(this, init);
    }
}
