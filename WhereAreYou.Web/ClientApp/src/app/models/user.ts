export class User {
    id: string;
    nickname: string;
    roomInviteHash: string;

    public constructor(init?: Partial<User>) {
        Object.assign(this, init);
    }
}
