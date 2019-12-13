using System.Collections.Generic;

namespace WhereAreYou.Core.Responses
{
    public class ValidationErrorsResponse : ErrorResponse
    {
        public List<ValidationErrorItem> ValidationErrors { get; set; }
    }
}
