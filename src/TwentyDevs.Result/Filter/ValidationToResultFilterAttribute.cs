using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace TwentyDevs.Result.Filter
{
    public class ValidationToResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors      = new SerializableError(context.ModelState);

                var result      = Result.Fail(errors); 
                var strJson     = JsonSerializer.Serialize(result);

                context.Result  = new ContentResult()
                {
                    Content = strJson, 
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

    }
}
