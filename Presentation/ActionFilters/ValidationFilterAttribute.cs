﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var param = context.ActionArguments.SingleOrDefault(c=>c.Value.ToString().Contains("Dto")).Value;

            if (param == null) 
            {
                context.Result = new BadRequestObjectResult($"Object is null. " + $"Controller : {controller}" + $"Action : {action}");
                return;
            }

            if(!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
