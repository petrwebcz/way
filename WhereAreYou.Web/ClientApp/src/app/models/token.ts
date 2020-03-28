
export class Token {
  jwt: string;

  public constructor(init?: Partial<Token>) {
    Object.assign(this, init);
  }
}

