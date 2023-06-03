namespace TwentyDevs.Result
{
    public partial class Result
    {
        /// <summary>
        /// Default text use for BadRequest Exception or BadRequest Status Code
        /// </summary>
        public static string BadRequestMessage     { get; set; } = "There are some errors with your request";

        /// <summary>
        /// 
        /// </summary>
        public static string NoContentMessage      { get; set; } = "There is No Informatino to Display";

        /// <summary>
        /// 
        /// </summary>
        public static string NotFoundMessage       { get; set; } = "Not fount any data";

        /// <summary>
        /// 
        /// </summary>
        public static string OKMessage             { get; set; } = "Your request was successcfully done.";

        /// <summary>
        /// 
        /// </summary>
        public static string UnauthorizedMessage   { get; set; } = "Authorize required";
        
    }
}
