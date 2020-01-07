"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ErrorType;
(function (ErrorType) {
    ErrorType[ErrorType["Validation"] = 0] = "Validation";
    ErrorType[ErrorType["Error"] = 1] = "Error";
    ErrorType[ErrorType["Critical"] = 2] = "Critical"; //Server application shits HTTP 5xx + Client unhadled exceptions (bugs)
})(ErrorType = exports.ErrorType || (exports.ErrorType = {}));
//# sourceMappingURL=error-type.js.map