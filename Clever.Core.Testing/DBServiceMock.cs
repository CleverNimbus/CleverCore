using Clever.Core.Persistence.DB;
using Moq;

namespace Clever.Core.Testing
{
	public static class DBServiceMock
	{
		public static int CountReturn { get; set; } = 0;
		public static int InsertReturn { get; set; } = 1;
		public static bool UpdateReturn { get; set; } = true;
		public static bool DeleteReturn { get; set; } = true;

		public static IDatabaseService GetDatabaseService()
		{
			var dbService = new Mock<IDatabaseService>();
			//TODO: Finish this
			//dbService.Setup(x => x.Count<AggregateRoot>()).Returns(CountReturn);
			//dbService.Setup(x => x.FindAll<AggregateRoot>()).Returns(new List<TEntity>());
			//dbService.Setup(x => x.Insert(It.IsAny<It.IsSubtype<AggregateRoot>>())).Returns(InsertReturn);
			//dbService.Setup(x => x.Update(It.IsAny<It.IsSubtype<AggregateRoot>>())).Returns(UpdateReturn);
			//dbService.Setup(x => x.Delete(It.IsAny<It.IsSubtype<AggregateRoot>>())).Returns(DeleteReturn);
			return dbService.Object;
		}
	}
}