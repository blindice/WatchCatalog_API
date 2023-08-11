﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WatchCatalog_API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult("Something went wrong!")
            {
                StatusCode = 500,
            };
            context.ExceptionHandled = true;
        }
    }
}