export class CreatedMeet {
    inviteUrl: string;
    inviteHash: string;
    name: string;

    public constructor(init?: Partial<CreatedMeet>) {
        Object.assign(this, init);
    }
}
