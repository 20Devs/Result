using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyDevs.Result
{
    public partial class Result<T> : Result
    {

        public T Value { get; private set; }

        internal Result() : base()
        { 
        }

        internal Result(T Value) : base()
        {
            this.Value = Value;
        }

        internal Result(bool IsSuccess, string Message) 
                : base(IsSuccess,Message)
        {
        }

        internal Result(string Message, T Value) : this(Value)
        {
            this.Message = Message;
        }

        internal Result(SerializableError ModelErrors) : base(ModelErrors)
        {
        }

        internal Result(ModelStateDictionary ModelState) : base(ModelState)
        {
        }

        public void   SetValue(T Value)
        {
           this.Value = Value;
        }

        //private Result   ToResult()
        //{
        //    Result result = new Result();

        //    foreach (var errorsKey in _errors.Keys)
        //    {
        //        foreach (var errorsValue in _errors.Values)
        //        {
        //            foreach (var errorMessage in errorsValue)
        //            {
        //                result.AddError(errorsKey, errorMessage);
        //            }
        //        }
        //    }

        //    return result;
        //}

    }
}
