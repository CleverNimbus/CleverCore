using Clever.Core.Persistence.DB;
using Clever.Core.Testing;
using System;
using System.Linq;

namespace Clever.Example.Tests
{
	public class Startup
	{
		private const string TESTED_ASSEMBLY_NAME = "Clever.Example";

		public static void ConfigureServices(IServiceCollection services)
		{
			var currentAssembly =
				AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(
					assembly => assembly.GetName().Name == TESTED_ASSEMBLY_NAME);

			if (currentAssembly == null)
			{
				throw new Exception("Unable to find tested assembly");
			}

			services.ConfigureTestingServicesFromAssembly(currentAssembly);

			//services.AddScoped<IDatabaseService>(DBServiceMock.GetDatabaseService());
		}
	}
}