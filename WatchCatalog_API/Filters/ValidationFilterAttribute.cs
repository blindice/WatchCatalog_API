using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Filters
{
    public class ValidationFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is null) return;

            var result = (ObjectResult)context.Result;

            if (result.StatusCode == 200)
            {
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.FirstOrDefault();

            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Endpoint Parameter is null");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
