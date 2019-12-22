
export class EnterTheRoom {
    nickname: string;
    inviteHash: string;
    inviteUrl: string;

    public constructor(init?: Partial<EnterTheRoom>) {
        Object.assign(this, init);
    }
}
