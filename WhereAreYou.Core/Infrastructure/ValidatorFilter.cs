using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereAreYou.Core.Exceptions;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.Core.Infrastructure
{
    public class ValidatorFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                if (!context.ModelState.IsValid)
                {
                    var modelState = context.ModelState;
                    var errors = context.ModelState.Keys
                        .SelectMany(key => modelState[key].Errors
                        .Select(x => new ValidationErrorItem(key, x.ErrorMessage)))
                        .ToList();
                  
                    var errorResponse = new ValidationErrorsResponse(errors);
                    context.Result = new BadRequestObjectResult(errors);
                }
            }
            var cnt = context.Controller;
        }
    }
}
