way.models.Room = function (cons, overrideObj) {
	if (!overrideObj) { overrideObj = { }; }
	if (!cons) { cons = { }; }
	var i, length;

	this.id = cons.id;
	this.name = cons.name;
	this.created = cons.created;
	this.lastUpdated = cons.lastUpdated;
	this.positions = new Array(cons.positions == null ? 0 : cons.positions.length );
	if(cons.positions != null) {
		for (i = 0, length = cons.positions.length; i < length; i++) {
			if (!overrideObj.IPosition) {
				this.positions[i] = new way.models.IPosition(cons.positions[i]);
			} else {
				this.positions[i] = new overrideObj.IPosition(cons.positions[i], overrideObj);
			}
		}
	}
	this.inviteUrl = cons.inviteUrl;
	this.inviteHash = cons.inviteHash;
	this.centerPoint = null;
	if (cons.centerPoint) {
		if (!overrideObj.ILocation) {
			this.centerPoint = new way.models.ILocation(cons.centerPoint);
		} else {
			this.centerPoint = new overrideObj.ILocation(cons.centerPoint, overrideObj);
		}
	}
}


way.models.IPosition = function (cons, overrideObj) {
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


way.models.ILocation = function (cons) {
	if (!cons) { cons = { }; }

	this.latitude = cons.latitude;
	this.longitude = cons.longitude;
}


