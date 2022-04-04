using Clever.Core.WebApi.Authorization.Checking.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clever.Core.WebApi.Filters
{
	public class PermissionCheckFilter : IActionFilter, IOrderedFilter
	{
		private IPermissionChecker _permissionChecker;

		public int Order { get; } = 0;

		public PermissionCheckFilter(
			[FromServices] IPermissionChecker permissionChecker)
		{
			_permissionChecker = permissionChecker;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (!_permissionChecker.Check(context))
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}