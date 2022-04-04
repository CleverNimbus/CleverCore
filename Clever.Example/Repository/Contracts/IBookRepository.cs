using Clever.Core.Persistence.Repository;
using Clever.Example.Models.Entities;

namespace Clever.Example.Repository.Contracts
{
	public interface IBookRepository : ICoreRepository<Book>
	{
	}
}