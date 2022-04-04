namespace Clever.Core.Persistence.DB
{
	public interface IDatabaseService : IDisposable
	{
		int Insert<TEntity>(TEntity entity) where TEntity : AggregateRoot, new();
		bool Update<TEntity>(TEntity entity) where TEntity : AggregateRoot, new();
		bool Delete<TEntity>(TEntity entity) where TEntity : AggregateRoot, new();
		int Count<TEntity>() where TEntity : AggregateRoot, new();
		IEnumerable<TEntity> FindAll<TEntity>() where TEntity : AggregateRoot, new();
	}
}