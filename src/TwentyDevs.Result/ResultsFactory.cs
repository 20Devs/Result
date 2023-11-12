 
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
namespace TwentyDevs.Result
{

    public partial class Result
    {
        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add ErrorMessage to the list of Errors and group it by an empty string.
        /// </summary>
        /// <param name="ErrorMessage">A string that describes the error </param>
        public static Result Fail(string ErrorMessage)
        {
            return new Result(false, ErrorMessage);
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add ErrorMessage to the list of Errors and group it by an MetaData string.
        /// </summary>
        /// <param name="MetaData">To group some errors under a name</param>
        /// <param name="ErrorMessage">A string that describes the error</param>
        public static Result Fail(string MetaData, string ErrorMessage)
        {
            var r = new Result();
            r.AddError(MetaData, ErrorMessage);
            return r;
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add all errors of ModelErrors to errors.
        ///<para>This factory method is useful for converting model validation to Result objects in Middleware, Filters, or Attributes.</para>
        /// </summary>
        /// <param name="ModelErrors"> A dictionary of errors. In fact, SerializableError inherits from Dictionary<string, object>  </param>
 
        public static Result Fail(SerializableError ModelErrors)
        {
            return new Result(ModelErrors);
        }
 

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add all errors of ModelState to errors.
        /// <para>This factory method is useful for converting model validation to Result objects in Middleware, Filters, or Attributes.</para>
        /// </summary>
        /// <param name="ModelState"> Validation Result to Add into errors</param>
        public static Result Fail(ModelStateDictionary ModelState)
        {
            return new Result(ModelState);
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add all errors of ModelState to errors.
        /// <para>This factory method is useful for converting Generic form of result to simple one without any data.</para>
        /// </summary>
        /// <param name="ModelState"> A dictionary of errors</param>
        public static Result Fail(Dictionary<string, List<string>> Errors )
        {
	        return new Result(Errors);
        }
 
        /// <summary>
        /// Instantiate a new Result as a success result that IsSuccess property equals true
        /// </summary> 
        public static Result Success()
        {
            return new Result();
        }

        /// <summary>
        /// Instantiate a new Result as a success result that IsSuccess property equals true
        /// and return a message as success message
        /// </summary>
        /// <param name="Message">Simple text to send to the client</param>
        public static Result Success(string Message)
        {
            return new Result(true, Message);
        }


        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add ErrorMessage to the list of Errors and group it by an MetaData string.
        /// return more info by AddValue Method as Data filed.
        /// </summary>
        /// <typeparam name="T">Type of Data that returns with result as Data field</typeparam>
        /// <param name="MetaData">To group some errors under a name</param>
        /// <param name="ErrorMessage">A string that describes the error</param>
        public static Result<T> Fail<T>(string MetaData, string ErrorMessage)
        {
            var r = new Result<T>();
            r.AddError(MetaData, ErrorMessage);
            return r;
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add ErrorMessage to the list of Errors and group it by an MetaData string.
        /// return more info by AddValue Method as Data filed. 
        /// </summary>
        /// <typeparam name="T">Type of Data that returns with result as Data field</typeparam>
        /// <param name="Errors">A dictionary of Errors to add to the instance of Result.</param>
        /// <returns></returns>
        public static Result<T> Fail<T>(Dictionary<string, List<string>> Errors)
        {
	        var r = new Result<T>();
	        r.AddError(Errors);
	        return r;
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add all errors of ModelState to errors.
        /// return more info by AddValue Method as Data filed.
        /// <para>This factory method is useful for converting model validation to Result objects in Middleware, Filters, or Attributes.</para>
        /// </summary>
        /// <typeparam name="T">Type of Data that returns with result as Data field</typeparam>
        /// <param name="ModelState"> Validation Result to Add into errors</param> 
 

        public static Result<T> Fail<T>(ModelStateDictionary ModelState)
        {
            return new Result<T>(ModelState);
        }
 
        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add all errors of ModelErrors to errors.
        /// return more info by AddValue Method as Data filed.
        ///<para>This factory method is useful for converting model validation to Result objects in Middleware, Filters, or Attributes.</para>
        /// </summary>
        /// <typeparam name="T">Type of Data that returns with result as Data field</typeparam>
        /// <param name="ModelErrors"> A dictionary of errors. In fact, SerializableError inherits from Dictionary<string, object>  </param>
 
        public static Result<T> Fail<T>(SerializableError ModelErrors)
        {
            return new Result<T>(ModelErrors);
        }
 
        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add ErrorMessage to the list of Errors and group it by an empty string.
        /// return more info by AddValue Method as Data filed.
        /// </summary>
        /// <typeparam name="T">Type of Data that returns with result as Data field</typeparam>
        /// <param name="ErrorMessage">A string that describes the error </param>
        public static Result<T> Fail<T>(string ErrorMessage)
        {
            return new Result<T>(false, ErrorMessage);
        }


        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// return Value as Data field .
        /// </summary>
        /// <typeparam name="T">Type of info that returns with result as Data field</typeparam>
        /// <param name="Data">More info return with result as Data field</param>
        public static Result<T> Fail<T>(T Data)
        {
            var r = new Result<T>(Data);
            r.AddError("", "");
            return r;
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// return Value as Data field and ErrorMessage as error.
        /// </summary>
        /// <typeparam name="T">Type of info that returns with result as Data field</typeparam>
        /// <param name="Data">More info return with result as Data field</param>
        /// <param name="ErrorMessage">A string that describes the error </param>
        public static Result<T> Fail<T>(T Data, string ErrorMessage)
        {
            var r = new Result<T>(Data);
            r.AddError("", ErrorMessage);
            return r;
        }

        /// <summary>
        /// Instantiate a new Result as a Failure result that IsSuccess property equals false and
        /// add all errors of ModelState to errors.
        /// <para>This factory method is useful for converting Generic form of result to simple one without any data.</para>
        /// </summary>
        /// <param name="ModelState"> A dictionary of errors </param>
        public static Result<T> Fail<T>(T Data, Dictionary<string, List<string>> Errors)
        {
	        var r = new Result<T>(Data);
	        r.AddError(Errors);
	        return r;
        }


        /// <summary>
        /// Instantiate a new Result as a success result that IsSuccess property equals true
        /// and return Value object as Data field 
        /// </summary>
        /// <typeparam name="T">Type of Value that returns with result as Data field</typeparam>
        /// <param name="Data">More info return with result as Data field</param>
        public static Result<T> Success<T>(T Data)
        {
            return new Result<T>(Data);
        }

        /// <summary>
        /// Instantiate a new Result as a success result that IsSuccess property equals true
        /// and return Value object as Data field 
        /// </summary>
        /// <typeparam name="T">Type of Value that returns with result as Data field</typeparam>
        /// <param name="Data">More info return with result as Data field</param>
        /// <param name="SuccessMessage">A string that describes the success result</param>
        public static Result<T> Success<T>(T Data, string SuccessMessage)
        {
            return new Result<T>(SuccessMessage, Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Result<T> Success<T>()
        {
	        return new Result<T>();
        }
         
    }
}
