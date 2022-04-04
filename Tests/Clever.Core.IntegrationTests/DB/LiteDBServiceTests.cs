using Clever.Core.Persistence.DB;
using Clever.Core.Persistence.Repository;
using System;

namespace Clever.Core.IntegrationTests.DB
{
	public class LiteDBServiceTests
	{
		//[Fact]
		//public void ServiceRetrieveOk()
		//{
		//	Assert.NotNull(ServiceOrchestrator.Instance.ServiceProvider);

		//	var dbService = ServiceOrchestrator.Instance.ServiceProvider.GetService<IDatabaseService>();
		//	Assert.NotNull(dbService);
		//}

		//[Theory, MemberData(nameof(PocoData))]
		//public void InsertOk(string text, DateTime date)
		//{
		//	using var dalService = new CoreRepository<LitePOCO>();

		//	var countInit = dalService.Count();

		//	int insertedId = 0;
		//	var exception = Record.Exception(() => insertedId = dalService.Insert(new LitePOCO { Text = text, Date = date }));
		//	Assert.Null(exception);
		//	Assert.NotEqual(0m, insertedId, 0);

		//	var countEnd = dalService.Count();
		//	Assert.Equal(1m, countEnd - countInit, 0);
		//}

		//#region Test helpers
		//internal record LitePOCO : AggregateRoot
		//{
		//	public string Text { get; set; } = default!;
		//	public DateTime Date { get; set; }
		//}

		//public static readonly object[][] PocoData =
		//{
		//	new object[] { "title 1", new DateTime(2021, 1, 1)},
		//	new object[] { "title 2", new DateTime(2021, 12, 1)},
		//	new object[] { "title 3", new DateTime(2021, 11, 1)},
		//	new object[] { "title 4", new DateTime(2022, 10, 3)},
		//	new object[] { "title 5", new DateTime(2020, 9, 3)},
		//	new object[] { "title 6", new DateTime(2020, 8, 1)},
		//	new object[] { "title 7", new DateTime(2020, 7, 1)}
		//};
		//#endregion Test helpers
	}
}