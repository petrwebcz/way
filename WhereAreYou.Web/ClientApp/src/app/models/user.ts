export class User {
    id: string;
    nickname: string;
    meetInviteHash: string;

    public constructor(init?: Partial<User>) {
        Object.assign(this, init);
    }
}
