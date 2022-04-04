using Clever.Core.Domain;
using Clever.Core.Persistence.Repository;
using Clever.Core.Service.Factories.Contracts;
using System.Reflection;

namespace Clever.Core.Service.Factories
{
	public static class Factory
	{
		private static string GetSiteRoot()
		{
			var codeBase = Assembly.GetExecutingAssembly().Location;
			var uri = new UriBuilder(codeBase);
			var path = Uri.UnescapeDataString(uri.Path);
			return Path.GetDirectoryName(path);
		}

		public static void ConfigureFactory(
			this IServiceCollection serviceCollection,
			string explorationPath,
			string explorationPattern,
			IEntryPointsCacheManager? entryPointsCacheManager = null)
		{
			var assembliesPath = Path.Combine(GetSiteRoot(), explorationPath);

			var fileAssemblies = Directory.GetFiles(
				assembliesPath,
				explorationPattern,
				SearchOption.AllDirectories);

			foreach (var fileAssembly in fileAssemblies)
			{
				var assembly = FactoryLoadContext.Instance.LoadFromAssemblyPath(fileAssembly);

				serviceCollection.ConfigureAssembly(assembly, true, entryPointsCacheManager);
			}
		}

		public static void ConfigureAssembly(
			this IServiceCollection services,
			Assembly assemblyToLoad,
			bool registerEntryPointsInCacheManager,
			IEntryPointsCacheManager? entryPointsCacheManager = null)
		{
			var domainBaseType = typeof(ICoreDomain);
			var repositoryBaseType = typeof(IBaseCoreRepository);

			foreach (var registrableType in assemblyToLoad.DefinedTypes
					.Where(t => !t.IsInterface &&
								!t.IsAbstract &&
								 t.IsClass &&
								 (domainBaseType.IsAssignableFrom(t) || repositoryBaseType.IsAssignableFrom(t))))
			{
				//TODO: Improve the "!name.contains"
				foreach (var interf in registrableType.GetInterfaces().Where(t => t != domainBaseType && t != repositoryBaseType
					&& !t.Name.Contains("ICoreRepository")
					&& !t.Name.Contains("IDisposable")))
				{
					services.AddScoped(interf, registrableType);

					if (registerEntryPointsInCacheManager)
					{
						ServiceOrchestrator.Instance.RebuildProvider();
						if (entryPointsCacheManager != null && domainBaseType.IsAssignableFrom(registrableType))
						{
							entryPointsCacheManager.RegisterEntryPoint(interf, assemblyToLoad.GetName().Name, interf.FullName);
						}
					}
				}
			}
		}
	}
}