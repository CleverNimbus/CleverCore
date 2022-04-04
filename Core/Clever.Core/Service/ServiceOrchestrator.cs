using Clever.Core.Persistence.DB;
using Clever.Core.Persistence.DB.Services;
using Microsoft.Extensions.Logging;

namespace Clever.Core.Service
{
	public class ServiceOrchestrator
	{
		public static ServiceOrchestrator Instance { get; set; }

		public ServiceProvider ServiceProvider { get; set; } = default!;

		public ILogger Logger
		{
			get
			{
				return ServiceProvider.GetService<ILoggerFactory>().CreateLogger<AggregateRoot>();
			}
		}

		public IServiceCollection ServiceCollection { get; set; }

		public void AddInternalServices()
		{
			ServiceCollection
				.AddLogging()
				.AddScoped<IDatabaseService, LiteDBService>();
		}

		public void RebuildProvider()
		{
			ServiceProvider = ServiceCollection.BuildServiceProvider();
		}
	}
}