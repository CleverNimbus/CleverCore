using Clever.Core.Persistence.DB;

namespace Clever.Core.Persistence.Repository
{
	public class CoreRepository<TEntity> : ICoreRepository<TEntity>, IDisposable
		where TEntity : AggregateRoot, new()
	{
		private IDatabaseService DatabaseService { get; set; } = default!;

		public CoreRepository(IDatabaseService databaseService) => DatabaseService = databaseService;

		public int Count()
		{
			return DatabaseService.Count<TEntity>();
		}

		public bool Delete(TEntity entity)
		{
			return DatabaseService.Delete(entity);
		}

		public IEnumerable<TEntity> FindAll()
		{
			return DatabaseService.FindAll<TEntity>();
		}

		public int Insert(TEntity entity)
		{
			return DatabaseService.Insert(entity);
		}

		public bool Update(TEntity entity)
		{
			return DatabaseService.Update(entity);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
				return;

			//if (DatabaseService == null)
				//return;
			//DatabaseService.Dispose();
		}
	}
}