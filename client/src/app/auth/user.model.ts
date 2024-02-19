export class User {
  constructor(
    public id: string,
    public username: string,
    public email: string,
    public role: string,
    public avatar: string,
    public bannedBy: string,
    private _token: string,
    private _tokenExpirationDate: Date
  ) {}

  get token() {
    if (!this._tokenExpirationDate || new Date() > this._tokenExpirationDate) {
      return null;
    }
    return this._token;
  }
}
