export class Room {
    id: string;
    name: string;
    created: string;
    lastUpdated: string;
    positions: Position[];
    inviteUrl: string;
    inviteHash: string;
    centerPoint: Location;

    public constructor(init?: Partial<Room>) {
        Object.assign(this, init);
    }
}
