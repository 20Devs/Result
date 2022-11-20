using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TwentyDevs.Result.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ResultExceptionFilter> _logger;

        /// <summary>
        /// 
        /// </summary>
        public bool     LogException    { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string   Message         { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public ResultExceptionFilter
            (
                ILogger<ResultExceptionFilter> logger,
                bool LogException,
                string Message
            )
        {
            _logger             = logger;
            this.LogException   = LogException;
            this.Message        = Message;
        }

        public override void OnException(ExceptionContext context)
        {
            Task.Run(async () => { await OnExceptionAsync(context); });
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if (LogException)
                _logger.LogError(context.Exception, Message);

            var result = Result.Fail<object>(Message);

            if (Debugger.IsAttached)
            {

                result.AddError(nameof(context.Exception.StackTrace), context.Exception.StackTrace);
                result.AddError(nameof(context.Exception.HelpLink), context.Exception.HelpLink);
                result.AddError(nameof(context.Exception.HelpLink), context.Exception.HelpLink);
                result.AddError(nameof(context.Exception.Source), context.Exception.Source);

                if (context.Exception.InnerException!=null)
                    result.AddError(nameof(context.Exception.InnerException), context.Exception.InnerException.Message);
            }

            result.AddError(nameof(context.Exception), context.Exception.Message);
            result.SetValue(context.Exception.Data);

            context.HttpContext.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(result);

            await context.HttpContext.Response.WriteAsync(json).ConfigureAwait(false);
        }
    }
}
