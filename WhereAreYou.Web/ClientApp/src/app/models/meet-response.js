"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var position_1 = require("./position");
var location_1 = require("./location");
var MeetResponse = /** @class */ (function () {
    function MeetResponse() {
        this.currentUser = new position_1.Position();
        this.centerPoint = new location_1.Location();
        this.users = new Array();
    }
    return MeetResponse;
}());
exports.MeetResponse = MeetResponse;
//# sourceMappingURL=meet-response.js.map