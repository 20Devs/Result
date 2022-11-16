using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyDevs.Result
{
    public partial class Result
    {
        public static string BadRequestMessage     { get; set; } = "There are some errors with your request";
        public static string NoContentMessage      { get; set; } = "There is No Informatino to Display";
        public static string NotFoundMessage       { get; set; } = "Not fount any data";
        public static string OKMessage             { get; set; } = "Your request was successcfully done.";
        public static string UnauthorizedMessage   { get; set; } = "Authorize required";

        
    }
}
