using System;
using System.Collections.Generic;

namespace WhereAreYou.Core.Responses
{
    public class ValidationErrorsResponse : ErrorResponse
    {
        public ValidationErrorsResponse(List<ValidationErrorItem> validationErrors)
        {
            ValidationErrors = validationErrors ?? throw new ArgumentNullException(nameof(validationErrors));
        }

        public List<ValidationErrorItem> ValidationErrors { get; set; }
    }
}
