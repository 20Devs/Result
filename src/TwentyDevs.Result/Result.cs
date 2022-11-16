using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TwentyDevs.Result
{
    [JsonConverter(typeof(ResultConverter))]
    public partial class Result
    {
        public string    Message         { get; set; }

        public string    Redirect        { get; set; }

        public bool     IsSuccess       => !_errors.Any();

        public Dictionary<string, List<string>> Errors => _errors;

        protected Dictionary<string, List<string>> _errors;

        protected Result()
        {
            _errors = new Dictionary<string, List<string>>();
        }

        protected Result(bool IsSuccess, string Message) : this()
        {
            if (IsSuccess)
                this.Message = Message;
            else
                AddError("", Message);
        }

        protected Result(SerializableError ModelErrors) : this()
        {
            foreach (var Model in ModelErrors)
            {
                if (Model.Value is string[] errors)
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

        protected Result(ModelStateDictionary ModelState) : this(new SerializableError(ModelState))
        {

        }

        public void AddError(string MemberName, string ErrorMessage)
        {

            if (_errors.ContainsKey(MemberName))
            {
                var values = _errors[MemberName];
                values.Add(ErrorMessage);
                _errors[MemberName] = values;
            }
            else
            {
                _errors.Add(MemberName, new List<string>() { ErrorMessage });
            }
        }

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

    }
}
