export class CreatedRoom {
    inviteUrl: string;
    inviteHash: string;
    name: string;

    public constructor(init?: Partial<CreatedRoom>) {
        Object.assign(this, init);
    }
}
