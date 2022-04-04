using Clever.Core.WebApi.Authentication.JWT.Entities;

namespace Clever.Core.WebApi.Authentication.JWT.Contracts
{
	public interface ITokenService
	{
		string BuildToken(string key, string issuer, UserDto user, TimeSpan expiryDuration);
	}
}