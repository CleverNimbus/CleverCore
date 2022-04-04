using Clever.Core.Service.Factories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clever.Core.Testing
{
	public static class ServiceConfigurator
	{
		public static void ConfigureTestingServicesFromAssembly(
			this IServiceCollection services,
			Assembly assemblyToLoad)
		{
			services.ConfigureAssembly(assemblyToLoad, false);
		}
	}
}