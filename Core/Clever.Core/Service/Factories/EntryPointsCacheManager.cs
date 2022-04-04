using Clever.Core.Exceptions;
using Clever.Core.Extensions;
using Clever.Core.Service.Factories.Contracts;
using Clever.Core.Service.Infraestructure;
using System.Text.Json.Nodes;

namespace Clever.Core.Service.Factories
{
	public class EntryPointsCacheManager : IEntryPointsCacheManager
	{
		private List<EntryPointItem> EntryPoints { get; set; } = new List<EntryPointItem>();

		public void RegisterEntryPoint(Type contractType, string assemblyName, string contractName)
		{
			var classMethods = contractType.GetClassMethods();
			foreach (var classMethod in classMethods)
			{
				var service = ServiceOrchestrator.Instance.ServiceProvider.GetService(contractType);
				var parameters = classMethod.GetParameters();
				var cosa = parameters.OrderBy(t => t.Position).Select(t => t.ParameterType).ToArray();
				var newEntryPoint = new EntryPointItem(assemblyName, contractName, classMethod.Name)
				{
					ContractType = contractType,
					ContractInstance = service,
					MethodInfo = classMethod,
					FunctionParamTypes = parameters.OrderBy(t => t.Position).Select(t => t.ParameterType).ToArray()
				};

				EntryPoints.Add(newEntryPoint);
			}
		}

		public CallEntry GetCallEntry(string assemblyName, string contractName, string methodName, string value)
		{
			var entryPoints = EntryPoints.Where(t => t.AssemblyName == assemblyName && t.ContractName == contractName && t.MethodName == methodName);

			if (!entryPoints.Any())
			{
				throw new WrongCallException($"Unable to Find method {methodName} in contract {contractName}");
			}

			var parameters = GetJSONParameters(value);
			var rightEntryPoint = GetEntryPoint(entryPoints, ref parameters);

			if (rightEntryPoint == null)
			{
				throw new WrongCallException($"Unable to Find method {methodName} in contract {contractName} with values {value}");
			}

			return new CallEntry(rightEntryPoint, parameters);
		}

		private object[] GetJSONParameters(string parameters)
		{
			var inputJson = JsonNode.Parse(parameters);
			var result = inputJson["Parameters"].AsArray().ToArray<object>();

			return result;
		}

		private EntryPointItem GetEntryPoint(IEnumerable<EntryPointItem> entryPoints, ref object[] parameters)
		{
			var paramLenght = parameters.Length;
			var possibleEntries = entryPoints.Where(t => t.FunctionParamTypes.Length == paramLenght);

			if (possibleEntries.Count() == 1)
			{
				var realParameters = GetRealParameters(possibleEntries.First(), ref parameters);
				if (realParameters != null)
				{
					parameters = realParameters.ToArray();
					return possibleEntries.First();
				}
			}
			else
			{
				foreach (var entryPoint in possibleEntries)
				{
					var realParameters = GetRealParameters(entryPoint, ref parameters);
					if (realParameters != null)
					{
						parameters = realParameters.ToArray();
						return entryPoint;
					}
				}
			}

			return null;
		}

		private List<object> GetRealParameters(EntryPointItem entryPoint, ref object[] parameters)
		{
			var realParameters = new List<object>();

			for (int i = 0; i < entryPoint.FunctionParamTypes.Length; i++)
			{
				if (!parameters[i].ToString().CanBeConvertedToType(entryPoint.FunctionParamTypes[i].GetUnderlyingType(), out object realResult))
				{
					return null;
				}
				realParameters.Add(realResult);
			}

			return realParameters;
		}

		public IEnumerable<EntryPointItem> GetAllEntryPoints()
		{
			return EntryPoints;
		}
	}
}