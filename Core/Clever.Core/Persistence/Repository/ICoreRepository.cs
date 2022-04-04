using Clever.Core.Persistence.DB;

namespace Clever.Core.Persistence.Repository
{
	public interface ICoreRepository<TEntity> : IDisposable, IBaseCoreRepository
		where TEntity : AggregateRoot, new()
	{
		int Insert(TEntity entity);

		bool Update(TEntity entity);

		bool Delete(TEntity entity);

		int Count();

		IEnumerable<TEntity> FindAll();
	}
}