

using System.Text.Json.Serialization;

namespace TwentyDevs.Result
{
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
 
    /// <summary>
    /// Defines a result to forming the response, output of methods,
    /// and returns of the actions to equalization.
    /// The Generic of this class returns additional data with T kind.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ResultGenericJsonConverter]
    public partial class Result<T> : Result
    {
        /// <summary>
        /// Additional Data to send with the result to the client
        /// </summary>
        public T Data { get; private set; }
        
        internal Result() : base()
        { 
        }

        internal Result(T Data) : base()
        {
            this.Data = Data;
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
        
        /// <summary>
        /// For set, Additional Data that sends to the client.
        /// </summary>
        /// <param name="Data">Additional information to Data property</param>
        public void   SetValue(T Data)
        {
           this.Data = Data;
        }
    }
}
