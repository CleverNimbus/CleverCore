using Clever.Core.WebApi.Authentication.JWT.Contracts;
using Clever.Core.WebApi.Authentication.JWT.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clever.Core.WebApi.Authentication.JWT.Services
{
	public class TokenService : ITokenService
	{
		public string BuildToken(string key, string issuer, UserDto user, TimeSpan expiryDuration)
		{
			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
			 };

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new JwtSecurityToken(
				issuer,
				issuer,
				claims,
				expires: DateTime.Now.Add(expiryDuration),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}
	}
}