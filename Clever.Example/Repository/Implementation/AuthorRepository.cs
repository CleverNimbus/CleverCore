using Clever.Core.Persistence.DB;
using Clever.Core.Persistence.Repository;
using Clever.Example.Models.Entities;
using Clever.Example.Repository.Contracts;

namespace Clever.Example.Repository.Implementation
{
	public class AuthorRepository : CoreRepository<Author>, IAuthorRepository
	{
		public AuthorRepository(IDatabaseService databaseService) : base(databaseService)
		{
		}
	}
}