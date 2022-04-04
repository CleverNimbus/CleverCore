using Clever.Core.WebApi.Authorization.Checking.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clever.Core.WebApi.Authorization.Checking.Services
{
	public class AuthorizeAllPermissionChecker : IPermissionChecker
	{
		//private readonly IConfiguration _configuration;
		//public AllAuthorizedPermissionChecker([FromServices] IConfiguration configuration)
		//{
		//	_configuration = configuration;
		//}

		public bool Check(ActionExecutingContext context)
		{
			//if (!bool.Parse(_configuration["Jwt:UseJwt"]))
			//	return true;

			//var controller = (ControllerBase)context.Controller;
			//var action = context.RouteData.Values["action"].ToString();
			//var url = context.HttpContext.Request.GetDisplayUrl();

			//if (string.IsNullOrWhiteSpace(context.HttpContext.User.FindFirst(_claimType)?.Value))
			//	context.Result = new UnauthorizedResult();
			return true;
		}
	}
}