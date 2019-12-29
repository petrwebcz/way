using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WhereAreYou.Core.Extensions;
using WhereAreYou.MeetApi.Controllers;

namespace WhereAreYou.MeetApi.Infrastructure
{
    public class UserDataActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is WayController controller))
                throw new Exception("Only WayController base class is allowed");

            var user = context.HttpContext.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;

            controller.UserData = user.Claims
                .FirstOrDefault(f => f.Type == ClaimTypes.UserData)
                .ToUserData();
        }
    }
}
