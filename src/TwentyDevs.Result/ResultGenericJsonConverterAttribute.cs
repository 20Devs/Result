using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace TwentyDevs.Result
{
	public class ResultGenericJsonConverterAttribute : JsonConverterAttribute
	{
		public override JsonConverter CreateConverter(Type typeToConvert)
		{
			if (typeToConvert.BaseType != typeof(Result) && !typeToConvert.IsGenericType )
				throw new Exception("Can only use this attribute on Result class");

			var keyType = typeToConvert.GenericTypeArguments[0];
			var converterType = typeof(ResultGenericConverter<>).MakeGenericType(keyType);

			return (JsonConverter)Activator.CreateInstance(converterType);
		}

	}
}
