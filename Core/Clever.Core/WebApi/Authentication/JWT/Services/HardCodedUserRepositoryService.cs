using Clever.Core.WebApi.Authentication.JWT.Contracts;
using Clever.Core.WebApi.Authentication.JWT.Entities;

namespace Clever.Core.WebApi.Authentication.JWT.Services
{
	public class HardCodedUserRepositoryService : IUserRepositoryService
	{
		private static List<UserDto> Users => new()
		{
			new("Sefe", "sefe"),
			new("Vigueras", "cvigueras")
		};

		public UserDto GetUser(UserModel userModel)
		{
			return Users.FirstOrDefault(x => string.Equals(x.UserName, userModel.UserName) && string.Equals(x.Password, userModel.Password));
		}
	}
}