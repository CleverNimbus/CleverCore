using Microsoft.AspNetCore.Authorization;

namespace Clever.Core.WebApi.Authentication.Anonymous
{
	public class AnonymousAuthorizationHandler : IAuthorizationHandler
	{
		public Task HandleAsync(AuthorizationHandlerContext context)
		{
			foreach (IAuthorizationRequirement requirement in context.PendingRequirements.ToList())
				context.Succeed(requirement);

			return Task.CompletedTask;
		}
	}
}