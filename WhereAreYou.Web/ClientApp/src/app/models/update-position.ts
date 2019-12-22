export class UpdatePosition {
    location: Location;

    public constructor(init?: Partial<UpdatePosition>) {
        Object.assign(this, init);
    }
}
