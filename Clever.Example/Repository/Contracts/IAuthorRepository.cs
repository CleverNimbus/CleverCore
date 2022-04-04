using Clever.Core.Persistence.Repository;
using Clever.Example.Models.Entities;

namespace Clever.Example.Repository.Contracts
{
	public interface IAuthorRepository : ICoreRepository<Author>
	{
	}
}