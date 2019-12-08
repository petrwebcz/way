way.models.CreatedRoom = function (cons) {
	if (!cons) { cons = { }; }

	this.inviteUrl = cons.inviteUrl;
	this.inviteHash = cons.inviteHash;
	this.name = cons.name;
}


