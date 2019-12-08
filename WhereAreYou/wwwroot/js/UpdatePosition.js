way.models.UpdatePosition = function (cons, overrideObj) {
	if (!overrideObj) { overrideObj = { }; }
	if (!cons) { cons = { }; }

	this.location = null;
	if (cons.location) {
		if (!overrideObj.Location) {
			this.location = new way.models.Location(cons.location);
		} else {
			this.location = new overrideObj.Location(cons.location, overrideObj);
		}
	}
}


way.models.Location = function (cons) {
	if (!cons) { cons = { }; }

	this.latitude = cons.latitude;
	this.longitude = cons.longitude;
}


