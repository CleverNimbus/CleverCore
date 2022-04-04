using Clever.Core.Persistence.DB;
using Clever.Core.Persistence.Repository;
using Clever.Example.Models.Entities;
using Clever.Example.Repository.Contracts;

namespace Clever.Example.Repository.Implementation
{
	public class BookRepository : CoreRepository<Book>, IBookRepository
	{
		public BookRepository(IDatabaseService databaseService) : base(databaseService)
		{
		}
	}
}