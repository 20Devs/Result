using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwentyDevs.Result;
using TwentyDevs.Result.Filter;
using WebApi7.Dto;

namespace WebApi7.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[ResultResponse] 
	[ResultValidation]
	[TypeFilter(typeof(ResultExceptionFilter), Arguments = new object[] { false,"for controller" })]
	public class HomeController : ControllerBase
	{

		[HttpGet]
		public async Task<object>  Get()
		{
			throw new Exception("Sample error");

			var result = Result.Fail("خطا رخ داده بوده ");
			result.AddError("name","the first error.");
			result.AddError("name", "the first error2.");
			result.AddError("name", "the first error3.");

			return new { Hi = "خطا رخ داده بوده ", Ho = "خطا رخ داده بوده " };
			//return Ok(new {Hi= "خطا رخ داده بوده ",Ho= "خطا رخ داده بوده "});
			//return BadRequest();
			//return NotFound();
			//return NoContent();
			//return Content("String as Content");
			//return NoContent();
			//return Unauthorized();
		}

		[HttpPost]
		public async Task<object> Post(LoginDto form)
		{

			return Ok(null);
		} 
	}
}
