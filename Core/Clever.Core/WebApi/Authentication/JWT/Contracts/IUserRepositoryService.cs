using Clever.Core.WebApi.Authentication.JWT.Entities;

namespace Clever.Core.WebApi.Authentication.JWT.Contracts
{
	public interface IUserRepositoryService
	{
		UserDto GetUser(UserModel userModel);
	}
}