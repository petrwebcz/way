export class CreateMeet {
    name: string;

    public constructor(init?: Partial<CreateMeet>) {
        Object.assign(this, init);
    }
}
