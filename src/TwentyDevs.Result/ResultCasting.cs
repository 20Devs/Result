//////////////////////////////////////////////////////////////////////////////////////
///                                                                                ///
/// This file contains casting each StatusCodeResult to Result class.              ///
/// With the help of this conversion,                                              /// 
/// we guarantee that the web api returns the same type of result in any situation,///
/// and it is also of the Result type.                                             ///
///                                                                                ///
//////////////////////////////////////////////////////////////////////////////////////
namespace TwentyDevs.Result
{
    using Microsoft.AspNetCore.Mvc;
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
            return Result.Success(Result.NoContentMessage);
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
                return Result.Fail(errors,Result.UnauthorizedMessage);

            return Result.Fail(result.Value?.ToString() ?? Result.UnauthorizedMessage);
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
