using DevBetter.JsonExtensions;
using DevBetter.JsonExtensions.Extensions;
using System.ComponentModel;
using System.Text.Json;

namespace Clever.Core.Extensions
{
	/// <summary>
	/// String Extensions
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="targetType"></param>
		/// <param name="conversionResult"></param>
		/// <returns></returns>
		public static bool CanBeConvertedToType(this string input, Type targetType, out object conversionResult)
		{
			if (CanBeConvertedToSimpleType(input, targetType, out conversionResult))
			{
				return true;
			}

			if (CanBeConvertedToComplexType(input, targetType, out conversionResult))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="targetType"></param>
		/// <param name="conversionResult"></param>
		/// <returns></returns>
		private static bool CanBeConvertedToSimpleType(string input, Type targetType, out object conversionResult)
		{
			try
			{
				conversionResult = TypeDescriptor.GetConverter(targetType).ConvertFromString(input);
				return true;
			}
			catch
			{
				conversionResult = null;
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="targetType"></param>
		/// <param name="conversionResult"></param>
		/// <returns></returns>
		private static bool CanBeConvertedToComplexType(string input, Type targetType, out object conversionResult)
		{
			try
			{
				var deserializeOptions = new JsonSerializerOptions().SetMissingMemberHandling(MissingMemberHandling.Error);

				conversionResult = JsonSerializer.Deserialize(input, targetType, deserializeOptions);
				return true;
			}
			catch
			{
				conversionResult = null;
				return false;
			}
		}
	}
}