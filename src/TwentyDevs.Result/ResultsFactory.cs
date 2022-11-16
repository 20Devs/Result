using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyDevs.Result
{
    public partial class Result
    {

        public static Result Fail(string ErrorMessage)
        {
            return new Result(false, ErrorMessage);
        }

        public static Result Fail(string MetaData, string ErrorMessage)
        {
            var r = new Result();
            r.AddError(MetaData, ErrorMessage);
            return r;
        }

        public static Result Fail(SerializableError ModelErrors)
        {
            return new Result(ModelErrors);
        }


        public static Result Fail(ModelStateDictionary ModelState)
        {
            return new Result(ModelState);
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Success(string Message)
        {
            return new Result(true, Message);
        }



        public static Result<T> Fail<T>(string MetaData, string ErrorMessage)
        {
            var r = new Result<T>();
            r.AddError(MetaData, ErrorMessage);
            return r;
        }

        public static Result<T> Fail<T>(ModelStateDictionary ModelState)
        {
            return new Result<T>(ModelState);
        }

        public static Result<T> Fail<T>(SerializableError ModelErrors)
        {
            return new Result<T>(ModelErrors);
        }

        public static Result<T> Fail<T>(string ErrorMessage)
        {
            return new Result<T>(false, ErrorMessage);
        }

        public static Result<T> Fail<T>(T Value)
        {
            var r = new Result<T>(Value);
            r.AddError("", "");
            return r;
        }

        public static Result<T> Fail<T>(T Value, string Message)
        {
            var r = new Result<T>(Value);
            r.AddError("", Message);
            return r;
        }

        public static Result<T> Success<T>(T Value)
        {
            return new Result<T>(Value);
        }

        public static Result<T> Success<T>(T Value, string Message)
        {
            return new Result<T>(Message, Value);
        }


    }
}
