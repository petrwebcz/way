using System;

namespace WhereAreYou.Core.Responses
{
    public class ValidationErrorItem 
    {
        public ValidationErrorItem()
        {
           
        }
        public ValidationErrorItem(string property, string errorMessage)
        {
            Property = property ?? throw new ArgumentNullException(nameof(property));
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        public string Property { get; set; }
        public string ErrorMessage { get; set; }
    }
}