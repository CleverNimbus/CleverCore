using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Clever.Core.Persistence.DB.Services
{
	public class LiteDBService : IDatabaseService, IDisposable
	{
		private readonly ILiteDatabase _db;

		public LiteDBService(IConfiguration configuration)
		{
			_db = new LiteDatabase(configuration["DataBase:Name"]);
		}

		public int Insert<TEntity>(TEntity entity)
			where TEntity : AggregateRoot, new()
		{
			var collection = _db.GetCollection<TEntity>();
			return collection.Insert(entity);
		}

		public int Count<TEntity>()
			where TEntity : AggregateRoot, new()
		{
			var collection = _db.GetCollection<TEntity>();
			return collection.Count();
		}

		public bool Update<TEntity>(TEntity entity)
			where TEntity : AggregateRoot, new()
		{
			var collection = _db.GetCollection<TEntity>();
			return collection.Update(entity);
		}

		public bool Delete<TEntity>(TEntity entity)
			where TEntity : AggregateRoot, new()
		{
			var collection = _db.GetCollection<TEntity>();
			return collection.Delete(entity.Id);
		}

		public IEnumerable<TEntity> FindAll<TEntity>()
			where TEntity : AggregateRoot, new()
		{
			var collection = _db.GetCollection<TEntity>();
			return collection.FindAll();
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

			if (_db == null)
				return;

			_db.Dispose();
		}
	}
}