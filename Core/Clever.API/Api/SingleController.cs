#if SINGLE_ENTRYPOINT
using Clever.Core.Domain;
using Clever.Core.Exceptions;
using Clever.Core.Extensions;
using Clever.Core.Results;
using Clever.Core.Service;
using Clever.Core.Service.Infraestructure;
using Clever.Core.WebApi.Filters;
using Microsoft.AspNetCore.Http.Extensions;
using System.Security.Claims;

namespace Clever.Api
{
	[ApiController]
	public class SingleController : Controller
	{
		[Authorize]
		[TypeFilter(typeof(PermissionCheckFilter))]
		[Route("api/{*url}")]
		[HttpPost]
		public async Task<IActionResult> Post(
			[FromBody] dynamic value,
			[FromServices] IEntryPointsCacheManager entryPointsCacheManager,
			[FromServices] IConfiguration configuration)
		{
			try
			{
				var requestedRouteElements = Request.ProcessRequest();
				var assemblyName = requestedRouteElements[4];
				var contractName = requestedRouteElements[5];
				var methodName = requestedRouteElements[6];
				var callValue = !string.IsNullOrEmpty(Convert.ToString(value)) ? value.ToString() : string.Empty;

				var callEntry = entryPointsCacheManager.GetCallEntry(assemblyName, contractName, methodName, callValue);

				FillRequestUserName(configuration, callEntry);

				return await ExecuteCall(callEntry);
			}
			catch (Exception ex)
			{
				var callException = new WrongCallException(
					$"An error has ocurred while resolving contract for path: '{Request.GetDisplayUrl()}'. Exception: {ex.Message}",
					ex);

				ServiceOrchestrator.Instance.Logger.LogError(
					callException,
					"WAPI Entry point exception");

				return BadRequest(new BackEndOperationResult(new OperationMessage(callException)));
			}
		}

		private void FillRequestUserName(IConfiguration configuration, CallEntry callEntry)
		{
			var userName = string.Empty;
			if (bool.Parse(configuration["Jwt:UseJwt"]))
			{
				userName = User.FindFirst(ClaimTypes.Name)?.Value;
			}

			((ICoreDomain)callEntry.EntryPointItem.ContractInstance).UserName = userName;
		}

		private async Task<IActionResult> ExecuteCall(CallEntry callEntry)
		{
			if (callEntry == null ||
				callEntry.EntryPointItem.ContractInstance == null ||
				callEntry.EntryPointItem.MethodInfo == null)
			{
				throw new NullReferenceException("Call Entry cannot be null");
			}

			return await Task.Run<IActionResult>(() =>
			{
				var resultBL = callEntry.EntryPointItem.MethodInfo.Invoke(callEntry.EntryPointItem.ContractInstance, callEntry.Parameters);

				if (resultBL is BackEndOperationResult rBl)
				{
					if (rBl.OperationResultSuccess)
					{
						return Ok(rBl);
					}

					return BadRequest(rBl);
				}
				else
				{
					return NotFound(new BackEndOperationResult("Backend call was unexpected"));
				}
			});
		}
	}
}
#endif