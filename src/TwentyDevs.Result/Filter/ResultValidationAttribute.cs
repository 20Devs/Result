
namespace TwentyDevs.Result.Filter
{ 
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Text.Json;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Actions when decorated with this attribute not excuted if there is a ModelState has any error.
    /// Result return back as BadRequest.
    /// </summary>
    public class ResultValidationAttribute : ActionFilterAttribute
    {
	    private readonly int _statusCodesResult;

	    public ResultValidationAttribute(int StatusCodesResult = StatusCodes.Status400BadRequest )
	    {
		    _statusCodesResult = StatusCodesResult;
	    }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var result      = Result.Fail(context.ModelState); 
                var strJson     = JsonSerializer.Serialize(result);

                context.Result  = new ResultResponse()
                {
                    Content     = strJson, 
                    ContentType = "application/json",
                    StatusCode  = _statusCodesResult
                };
            }
        }

    } 
}
