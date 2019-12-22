export class CreateRoom {
    name: string;

    public constructor(init?: Partial<CreateRoom>) {
        Object.assign(this, init);
    }
}
