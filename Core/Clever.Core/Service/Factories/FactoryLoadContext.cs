using System.Reflection;
using System.Runtime.Loader;

namespace Clever.Core.Service.Factories
{
	public class FactoryLoadContext : AssemblyLoadContext
	{
		public const string CORELOADCONTEXTNAME = "CoreLoadContext";

		public static FactoryLoadContext Instance { get; set; } = new FactoryLoadContext(CORELOADCONTEXTNAME);

		public static bool IsUnloading { get; set; } = false;

		public FactoryLoadContext(string loadContextName) : base(loadContextName, isCollectible: true)
		{
		}

		protected override Assembly Load(AssemblyName name)
		{
			return null;
		}

		public static void ResetAssembliesDomain()
		{
			IsUnloading = true;
			Instance.Unloading += FactoryLoadContext_Unloading;
			Instance.Unload();
		}

		private static void FactoryLoadContext_Unloading(AssemblyLoadContext obj)
		{
			try
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			catch (Exception) { /*sometimes GC.Collet/WaitForPendingFinalizers crashes, just ignore */ }

			Instance = new FactoryLoadContext(CORELOADCONTEXTNAME);
			IsUnloading = false;
		}
	}
}