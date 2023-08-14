using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WatchCatalog_API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new { message = context.Exception.Message, stackTrace = context.Exception.StackTrace })
            {
                StatusCode = 500,
            };
            context.ExceptionHandled = true;
        }
    }
}
