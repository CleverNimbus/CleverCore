using Clever.Core.Exceptions;
using Clever.Core.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Clever.Core.Service.Factories
{
	public class EntryPointItem
	{
		public string AssemblyName { get; private set; }
		public string ContractName { get; private set; }
		public string MethodName { get; private set; }

		public IEnumerable<string> FunctionParamTypesTxt
		{
			get
			{
				if (FunctionParamTypes == null)
					return Enumerable.Empty<string>();
				return FunctionParamTypes.Select(t => t.GetUnderlyingTypeAsString()).ToList();
			}
		}

		[JsonIgnore]
		public Type[]? FunctionParamTypes { get; set; }

		[JsonIgnore]
		public Type? ContractType { get; set; }

		[JsonIgnore]
		public MethodInfo? MethodInfo { get; set; }

		[JsonIgnore]
		public object? ContractInstance { get; set; }

		public EntryPointItem(string assemblyName, string contractName, string methodName)
		{
			if (string.IsNullOrWhiteSpace(assemblyName))
			{
				throw new WrongCallException("AssemblyName is empty");
			}
			AssemblyName = assemblyName;

			if (string.IsNullOrWhiteSpace(contractName))
			{
				throw new WrongCallException("ContractName is empty");
			}
			ContractName = contractName;

			if (string.IsNullOrWhiteSpace(methodName))
			{
				throw new WrongCallException("MethodName is empty");
			}
			MethodName = methodName;
		}
	}
}