import { ValidationErrorItem } from "./validation-error-item";
import { ErrorType } from "./error-type";

export class ErrorResponse {
    errorMessage: string;
    errorType: ErrorType;
    httpStatusCode: number;
   
    public constructor(init?: Partial<ErrorResponse>) {
        Object.assign(this, init);
    }
}
