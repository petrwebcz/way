way.models.Position = function (cons, overrideObj) {
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
	this.location = null;
	if (cons.location) {
		if (!overrideObj.Location) {
			this.location = new way.models.Location(cons.location);
		} else {
			this.location = new overrideObj.Location(cons.location, overrideObj);
		}
	}
}


way.models.User = function (cons) {
	if (!cons) { cons = { }; }

	this.id = cons.id;
	this.nickname = cons.nickname;
	this.roomInviteHash = cons.roomInviteHash;
}


way.models.Location = function (cons) {
	if (!cons) { cons = { }; }

	this.latitude = cons.latitude;
	this.longitude = cons.longitude;
}


