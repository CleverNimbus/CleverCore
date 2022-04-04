using System.ComponentModel.DataAnnotations;

namespace Clever.Core.WebApi.Authentication.JWT.Entities
{
	public record UserModel([Required] string UserName, [Required] string Password);
}