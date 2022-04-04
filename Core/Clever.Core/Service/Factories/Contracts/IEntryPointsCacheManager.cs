using Clever.Core.Service.Infraestructure;

namespace Clever.Core.Service.Factories.Contracts
{
	public interface IEntryPointsCacheManager
	{
		void RegisterEntryPoint(Type contractType, string assemblyName, string contractName);

		CallEntry GetCallEntry(string assemblyName, string contractName, string methodName, string value);

		IEnumerable<EntryPointItem> GetAllEntryPoints();
	}
}