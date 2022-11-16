using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwentyDevs.Result;

namespace WebApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<Result>  Get()
        {
            var result = Result.Fail("خطا رخ داده بوده ");
            result.AddError("name","the first error.");
            result.AddError("name", "the first error2.");
            result.AddError("name", "the first error3.");
            return result;
        }


    }
}
