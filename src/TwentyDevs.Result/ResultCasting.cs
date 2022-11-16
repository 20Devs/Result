using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace TwentyDevs.Result
{
    public partial class Result
    {
        public static implicit operator Result(OkResult result)
        {
            return Result.Success();
        }
        public static implicit operator Result(OkObjectResult result)
        {
            var r = Result.Success(result.Value);
            return r;
        }
        public static implicit operator Result(BadRequestResult result)
        {
            return Result.Fail(BadRequestMessage);
        }
        public static implicit operator Result(BadRequestObjectResult result)
        {
            if (result.Value is SerializableError errors)
                return Result.Fail(errors);

            return Result.Fail(result.Value?.ToString() ?? BadRequestMessage);
        }
        public static implicit operator Result(ContentResult result)
        {
            return Result.Success(result.Content);
        }
        public static implicit operator Result(NoContentResult result)
        {
            return Result.Success();
        }
        public static implicit operator Result(NotFoundResult result)
        {
            return Result.Fail(NotFoundMessage);
        }
        public static implicit operator Result(UnauthorizedResult result)
        {
            return Result.Fail(UnauthorizedMessage);
        }
        public static implicit operator Result(UnauthorizedObjectResult result)
        {
            if (result.Value is SerializableError errors)
                return Result.Fail(errors);

            return Result.Fail(result.Value?.ToString() ?? BadRequestMessage);
        }

    }

    public partial class Result<T> : Result
    {
        public static implicit operator Result<T>(T Value)
        {
            return Result.Success(Value);
        }
        public static implicit operator Result<T>(OkResult result)
        {
            return Result.Success(default(T));
        }
        public static implicit operator Result<T>(OkObjectResult result)
        {
            var r = Result.Success((T)result.Value);
            return r;
        }
        public static implicit operator Result<T>(BadRequestResult result)
        {
            return Result.Fail<T>(BadRequestMessage);
        }
        public static implicit operator Result<T>(BadRequestObjectResult result)
        {
            if (result.Value is SerializableError errors)
                return Result.Fail<T>(errors);

            return Result.Fail<T>(result.Value?.ToString() ?? BadRequestMessage);
        }
        public static implicit operator Result<T>(ContentResult result)
        {
            return Result.Success<T>(default(T));
        }
        public static implicit operator Result<T>(NoContentResult result)
        {
            return Result.Success<T>(default(T));
        }
        public static implicit operator Result<T>(NotFoundResult result)
        {
            return Result.Fail<T>(NotFoundMessage);
        }
        public static implicit operator Result<T>(UnauthorizedResult result)
        {
            return Result.Fail<T>(UnauthorizedMessage);
        }
        public static implicit operator Result<T>(UnauthorizedObjectResult result)
        {
            if (result.Value is SerializableError errors)
                return Result.Fail<T>(errors);

            return Result.Fail<T>(result.Value?.ToString() ?? BadRequestMessage);
        }

    }
}
