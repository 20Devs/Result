using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; 
using System.Text.Json.Serialization;
using System.Text.Json; 
 
namespace TwentyDevs.ResultCore
{
    /// <summary>
    /// Convert to/from json string  with custome converter 
    /// </summary>
    public class ResultGenericConverter<T> : JsonConverter<Result<T>>
    {
        public override Result<T> Read
            (
                ref Utf8JsonReader reader, 
                Type typeToConvert, 
                JsonSerializerOptions options
            )
        {

            Result<T> result;
            var resultType       = typeof(Result<T>);
            var resultProperties = resultType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            string name = null;

            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
	            name = jsonDoc.RootElement.GetRawText();
            }

            var source = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(name);

            var message =
                source.ContainsKey(nameof(Result.Message))
                ? source[nameof(Result.Message)].GetString()
                : null;

            if (source.ContainsKey(nameof(Result.IsSuccess)))
            {
	            var successValue = source[nameof(Result.IsSuccess)].GetBoolean();

	            if (successValue)
	            {
		            result = Result.Success<T>();
		            result.Message = message;
	            }
	            else
	            {
		            result = Result.Fail<T>(message);
	            }
            }
            else
            {
	            result = Result.Success<T>();
            }

            foreach (var s in source.Keys)
            {
                if (string.Compare(s, nameof(Result.IsSuccess), StringComparison.OrdinalIgnoreCase) == 0 
                    ||
                    string.Compare(s, nameof(Result.Message), StringComparison.OrdinalIgnoreCase) == 0
                    )
                {
                    continue;
                }
                
                var propertyInfo = resultProperties.FirstOrDefault(x => x.Name == s);

                if (propertyInfo != null)
                {
                    var value = JsonSerializer.Deserialize(source[s].GetRawText(), propertyInfo.PropertyType);

                    if (string.Compare(s, nameof(Result.Errors), StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        result.AddError((Dictionary<string, List<string>>)value);
                    }
                    else
                    {

                        resultType.InvokeMember(propertyInfo.Name,
                              BindingFlags.Public
                            | BindingFlags.NonPublic
                            | BindingFlags.SetProperty
                            | BindingFlags.Instance,
                            null,
                            result,
                            new object[] { value });

                    }
                }
            }

            return result;
        }

       

        public override void Write(Utf8JsonWriter writer, Result<T> value, JsonSerializerOptions options)
        {
            var props = value.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .ToDictionary(x => x.Name, x => x.GetValue(value));

            JsonSerializer.Serialize(writer,props,options);
        }
    }
}
