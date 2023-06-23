using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Configuration;
using Xunit;
//using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text.Json;
using TwentyDevs.Result;

namespace Result.Test
{
    public class ResultFactory
    {
        [Fact]
        public void Test_Result_Success_010()
        {
            //Arrange
            var result = TwentyDevs.Result.Result.Success();
            var strJson = JsonSerializer.Serialize(result);


            //Act
            var desrResult = JsonSerializer.Deserialize<TwentyDevs.Result.Result>(strJson);

            //Asset
            Assert.True(desrResult.IsSuccess);
        }

        [Fact]
        public void Test_Result_Fail_020()
        {
            //Arrange

            var result = TwentyDevs.Result.Result.Fail("Some Error Message");
            result.AddError("", "Reason 2 in model state");
            var strJson = JsonSerializer.Serialize(result);

            //Act
            var desrResult = JsonSerializer.Deserialize<TwentyDevs.Result.Result>(strJson);


            //Asset
            Assert.False(desrResult.IsSuccess);
        }

        [Fact]
        public void Test_Result_Success_030()
        {
	        //Arrange
	        var result = TwentyDevs.Result.Result.Success<string>();
	        
	        //Act


	        //Asset
	        Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Test_Result_Success_040()
        {
	        //Arrange
	        var result = TwentyDevs.Result.Result.Success<int>(32);
	        var strJson = JsonSerializer.Serialize(result);


	        //Act
	        var desrResult = JsonSerializer.Deserialize<TwentyDevs.Result.Result<int>>(strJson);

	        //Asset
	        Assert.True(desrResult.IsSuccess);
        }
    }

}
