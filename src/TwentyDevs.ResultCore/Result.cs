
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TwentyDevs.ResultCore
{
    /// <summary>
    /// Defines a result to forming the response, output of methods,
    /// and returns of the actions to equalization.
    /// </summary>
    [JsonConverter(typeof(ResultConverter))]
    public partial class Result
    {
        /// <summary>
        /// Desfines a message to send with result.success message or faild message
        /// </summary>
        public string    Message         { get; set; }

        /// <summary>
        /// Defines a URL, navigation, or path to redirect clients to favor destination
        /// </summary>
        public string    Redirect        { get; set; }

        /// <summary>
        /// Determines the result of operation or response(Success/Faild).
        /// </summary>
        public bool      IsSuccess       => !_errors.Any();

        /// <summary>
        /// A simple dictionary that return list of errors as string.
        /// <para>
        /// It is possible to group errors With Dictionary just like ModelState.
        /// </para>
        /// </summary>
        public Dictionary<string, List<string>> Errors => _errors;

        protected Dictionary<string, List<string>> _errors;

        protected Result()
        {
            _errors = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
        }

        protected Result(bool IsSuccess, string message) : this()
        {
	        this.Message = message;

            if (!IsSuccess && !string.IsNullOrWhiteSpace(message))
                AddError("", message);
        }

        protected Result(Dictionary<string, List<string>> ErrorDictionary) : this()
        {
	        _errors = ErrorDictionary;
        }

        /// <summary>
        /// Adds a string as an error description to the list of errors.
        /// </summary>
        /// <param name="MetaData">To group some errors under a name</param>
        /// <param name="ErrorMessage">A string that describes the error</param>
        public void AddError(string MetaData, string ErrorMessage)
        {
            if (string.IsNullOrWhiteSpace(ErrorMessage))
                return;

            if (_errors.ContainsKey(MetaData))
            {
                var values = _errors[MetaData];
                values.Add(ErrorMessage);
                _errors[MetaData] = values;
            }
            else
            {
                _errors.Add(MetaData, new List<string>() { ErrorMessage });
            }
        }
        /// <summary>
        /// Adds a collection of errors to the existing error list.
        /// </summary>
        /// <param name="Errors">A dictionary of errors for adding</param>
        public void AddError(Dictionary<string, List<string>> Errors)
        {
            foreach (var Model in Errors)
            {
                if (Model.Value is List<string> errors)
                {
                    foreach (var error in errors)
                    {
                        AddError(Model.Key, error);
                    }
                }
                else
                {
                    AddError(Model.Key, Model.Value?.ToString());
                }
            }
        }


        /// <summary>
        /// Adds a collection of errors to the existing error list as a MetaData.
        /// </summary>
        /// <param name="Errors">A dictionary of errors for adding</param>
        public void AddError(string MetaData, List<string> Errors)
        {
	        foreach (var error in Errors)
	        {
		        AddError(MetaData,error);
	        }
        }

    }
}
