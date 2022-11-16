using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace TwentyDevs.Result.Filter
{
    public class ResultFilterAttribute : ActionFilterAttribute
    {
        private ActionExecutedContext _Context;

        private void SetContextResult(Result result, int? statusCode)
        {
            var strJson         = JsonSerializer.Serialize(result);

            _Context.Result     = new ContentResult()
            {
                Content         = strJson,
                ContentType     = "application/json",
                StatusCode      = statusCode
            };
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _Context = context;
            switch (context.Result)
            {
                case OkObjectResult okObjectResult:
                    {
                        var OkResult    = Result.Success<object>(okObjectResult.Value);

                        SetContextResult(OkResult, StatusCodes.Status200OK);
                         
                        break;
                    }
                case OkResult okResult:
                    { 
                        SetContextResult(Result.Success(), StatusCodes.Status200OK);
                        break;
                    }
                case BadRequestResult badRequestResult:
                {
                        var BadRequestResult    = Result.Fail(Result.BadRequestMessage);
                        SetContextResult(BadRequestResult, StatusCodes.Status400BadRequest);

                        break;
                    }
                case BadRequestObjectResult badRequestObjectResult:
                    {

                        if (badRequestObjectResult.Value is SerializableError errors)
                        {
                            var BadRequestResult    = Result.Fail(errors);
                            SetContextResult(BadRequestResult, StatusCodes.Status400BadRequest);
                        }
                        else
                        {
                            var BadRequestResult    = Result.Fail<object>(badRequestObjectResult.Value);
                            SetContextResult(BadRequestResult, StatusCodes.Status400BadRequest);
                        }
                        
                        break;
                    }
                case ContentResult contentResult:
                    {
                        var ContentResult   = Result.Success(contentResult.Content);
                        SetContextResult(ContentResult, StatusCodes.Status200OK);

                        break;
                    }
                case NoContentResult noContentResult:
                    {
                        var NoContentResult = Result.Success(Result.NoContentMessage);
                        SetContextResult(NoContentResult, StatusCodes.Status204NoContent);

                        break;
                    }
                case NotFoundResult notFoundResult:
                    {
                        var NotFoundResult  = Result.Fail(Result.NotFoundMessage);
                        SetContextResult(NotFoundResult, StatusCodes.Status404NotFound);

                        break;
                    }
                case NotFoundObjectResult notFoundObjectResult:
                    {
                        
                        var NotFoundResult  = Result.Fail<object>(notFoundObjectResult.Value, Result.NotFoundMessage);
                        SetContextResult(NotFoundResult, StatusCodes.Status404NotFound);
                        break;
                    }
                case ObjectResult objectResult 
                when objectResult.StatusCode == null && !(objectResult.Value is Result):
                    {
                        var ObjectResult    = Result.Success(objectResult.Value);
                        SetContextResult(ObjectResult, StatusCodes.Status200OK);
                        break;
                    }
                case UnauthorizedResult unauthorizedResult:
                    {
                        var UnauthorizedResult  = Result.Fail(Result.UnauthorizedMessage);
                        SetContextResult(UnauthorizedResult, StatusCodes.Status401Unauthorized);

                        break;
                    }
                case UnauthorizedObjectResult unauthorizedObjectResult:
                    {
                        var UnauthorizedResult  = Result.Fail(unauthorizedObjectResult.Value, Result.UnauthorizedMessage);
                        SetContextResult(UnauthorizedResult, StatusCodes.Status401Unauthorized);

                        break; 
                    }
            }

            base.OnActionExecuted(context);
        }


    }
}
