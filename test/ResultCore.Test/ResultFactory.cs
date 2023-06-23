using System;
using System.Text.Json;
using Xunit;

namespace ResultCore.Test
{
	public class ResultFactory
	{
		[Fact]
		public void Test_Result_Success_010()
		{
			//Arrange
			var result = TwentyDevs.ResultCore.Result.Success();
			var strJson = JsonSerializer.Serialize(result);


			//Act
			var desrResult = JsonSerializer.Deserialize<TwentyDevs.ResultCore.Result>(strJson);

			//Asset
			Assert.True(desrResult.IsSuccess);
		}

		[Fact]
		public void Test_Result_Fail_020()
		{
			//Arrange

			var result = TwentyDevs.ResultCore.Result.Fail("Some Error Message");
			result.AddError("", "Reason 2 in model state");
			var strJson = JsonSerializer.Serialize(result);

			//Act
			var desrResult = JsonSerializer.Deserialize<TwentyDevs.ResultCore.Result>(strJson);


			//Asset
			Assert.False(desrResult.IsSuccess);
		}

		[Fact]
		public void Test_Result_Success_030()
		{
			//Arrange
			var result = TwentyDevs.ResultCore.Result.Success<string>();
	        
			//Act


			//Asset
			Assert.True(result.IsSuccess);
		}

		[Fact]
		public void Test_Result_Success_040()
		{
			//Arrange
			var result = TwentyDevs.ResultCore.Result.Success<int>(32);
			var strJson = JsonSerializer.Serialize(result);


			//Act
			var desrResult = JsonSerializer.Deserialize<TwentyDevs.ResultCore.Result<int>>(strJson);

			//Asset
			Assert.True(desrResult.IsSuccess);
		}
	}
}
