#if SINGLE_ENTRYPOINT
using Clever.Core.WebApi.Filters;

namespace Clever.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class EndPointsController : ControllerBase
	{
		private readonly IEntryPointsCacheManager _entryPointsCacheManager;
		public EndPointsController([FromServices] IEntryPointsCacheManager entryPointsCacheManager) : base()
		{
			_entryPointsCacheManager = entryPointsCacheManager;
		}

		[HttpGet]
		[Authorize]
		[TypeFilter(typeof(PermissionCheckFilter))]
		public IActionResult Get()
		{
			return Ok(new
			{
				EntryPoints = _entryPointsCacheManager.GetAllEntryPoints()
			});
		}
	}
}
#endif