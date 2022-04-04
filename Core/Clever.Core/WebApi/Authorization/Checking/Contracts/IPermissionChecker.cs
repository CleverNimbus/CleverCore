using Microsoft.AspNetCore.Mvc.Filters;

namespace Clever.Core.WebApi.Authorization.Checking.Contracts
{
	public interface IPermissionChecker
	{
		bool Check(ActionExecutingContext context);
	}
}