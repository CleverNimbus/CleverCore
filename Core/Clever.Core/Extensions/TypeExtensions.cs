using System.Reflection;

namespace Clever.Core.Extensions
{
	/// <summary>
	/// Type Extensions
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Returns all methods from given Type
		/// </summary>
		/// <param name="contractType">A Contract Type</param>
		/// <returns>List of available Methods</returns>
		public static IEnumerable<MethodInfo> GetClassMethods(this Type contractType)
		{
			var result = new List<MethodInfo>();

			var classMethods = contractType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(t => !t.IsSpecialName);

			if (classMethods != null && classMethods.Any() && classMethods.Any(x => !result.Contains(x)))
			{
				result.AddRange(classMethods.Where(x => !result.Contains(x)));
			}

			foreach (Type inheritedInterfaces in contractType.GetInterfaces())
			{
				var resultTmp = inheritedInterfaces.GetClassMethods();

				if (resultTmp != null && resultTmp.Any() && resultTmp.Any(x => !result.Contains(x)))
				{
					result.AddRange(resultTmp.Where(x => !result.Contains(x)));
				}
			}

			return result;
		}

		/// <summary>
		/// Returns he underling type in displaying format for a Nullable type
		/// </summary>
		/// <param name="nullableType">The nullable type</param>
		/// <returns>The underling type name</returns>
		public static string GetUnderlyingTypeAsString(this Type nullableType)
		{
			var type = nullableType.GetUnderlyingType(out bool isNullable);
			if (isNullable)
			{
				return $"Nullable<{type.Name}>";
			}
			return type.Name;
		}

		/// <summary>
		/// Returns he underling type for a Nullable type
		/// </summary>
		/// <param name="nullableType">The nullable type</param>
		/// <returns>The underling type</returns>
		public static Type GetUnderlyingType(this Type nullableType)
		{
			return nullableType.GetUnderlyingType(out bool _);
		}

		public static Type GetUnderlyingType(this Type nullableType, out bool isNullable)
		{
			Type result = nullableType;
			if (nullableType.IsGenericType && !nullableType.IsGenericTypeDefinition)
			{
				Type genericType = nullableType.GetGenericTypeDefinition();
				if (ReferenceEquals(genericType, typeof(Nullable<>)))
				{
					isNullable = true;
					return nullableType.GetGenericArguments()[0];
				}
			}
			isNullable = false;
			return result;
		}
	}
}