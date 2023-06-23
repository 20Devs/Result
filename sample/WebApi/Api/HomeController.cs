using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwentyDevs.Result;
using TwentyDevs.Result.Filter;
using WebApi.Models;

namespace WebApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [ResultResponse] 
    [TypeFilter(typeof(ResultExceptionFilter), Arguments = new object[] { true,"for controller" })]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public async Task<object>  Get()
        {
            //throw new Exception("Sample error");

            var result2 = TwentyDevs.Result.Result.Success<object>(Data:"Data");
            var strJson = JsonSerializer.Serialize(result2);


            //Act
            var desrResult = JsonSerializer.Deserialize<TwentyDevs.Result.Result<object>>(strJson);

            var result = Result.Fail("خطا رخ داده بوده ");
            result.AddError("name", "the first error.");
            result.AddError("name", "the first error2.");
            result.AddError("name", "the first error3.");

            return result;

            //return new { Hi = "خطا رخ داده بوده ", Ho = "خطا رخ داده بوده " };
            //return Ok(new {Hi= "خطا رخ داده بوده ",Ho= "خطا رخ داده بوده "});
            //return BadRequest();
            //return NotFound();
            //return NoContent();
            //return Content("String as Content");
            //return NoContent();
            //return Unauthorized();



        }

        [HttpPost]
        [ResultValidation(Order = 0)]
        public async Task<Result> Post([FromForm]SignupViewModel form)
        {
           
            return Ok(form);
           
        }

        [HttpPut]
        public async Task<Result> Put()
        {
            throw new Exception("Simple Error");
        }


        [HttpDelete]
        public async Task<Result> Delete()
        {
            return NotFound();
        }


    }
}
