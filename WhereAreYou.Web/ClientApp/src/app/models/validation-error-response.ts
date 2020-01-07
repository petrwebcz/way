import { ErrorResponse } from "./error-response";
import { ValidationErrorItem } from "./validation-error-item";

export class ValidationErrorResponse extends ErrorResponse {
    validationErrors: ValidationErrorItem;
}
