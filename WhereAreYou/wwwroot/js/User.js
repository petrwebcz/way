way.models.User = function (cons) {
	if (!cons) { cons = { }; }

	this.id = cons.id;
	this.nickname = cons.nickname;
	this.roomInviteHash = cons.roomInviteHash;
}


