way.models.UserData = function (cons, overrideObj) {
	if (!overrideObj) { overrideObj = { }; }
	if (!cons) { cons = { }; }

	this.user = null;
	if (cons.user) {
		if (!overrideObj.User) {
			this.user = new way.models.User(cons.user);
		} else {
			this.user = new overrideObj.User(cons.user, overrideObj);
		}
	}
	this.roomInviteHash = cons.roomInviteHash;
}


way.models.User = function (cons) {
	if (!cons) { cons = { }; }

	this.id = cons.id;
	this.nickname = cons.nickname;
	this.roomInviteHash = cons.roomInviteHash;
}


