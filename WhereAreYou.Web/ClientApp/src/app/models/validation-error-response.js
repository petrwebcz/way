"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var error_response_1 = require("./error-response");
var ValidationErrorResponse = /** @class */ (function (_super) {
    __extends(ValidationErrorResponse, _super);
    function ValidationErrorResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return ValidationErrorResponse;
}(error_response_1.ErrorResponse));
exports.ValidationErrorResponse = ValidationErrorResponse;
//# sourceMappingURL=validation-error-response.js.map