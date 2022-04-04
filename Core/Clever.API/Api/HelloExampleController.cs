#if !SINGLE_ENTRYPOINT
using Clever.Core.WebApi.Filters;

namespace Clever.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class HelloExampleController : ControllerBase
	{
		[HttpGet]
		[Authorize]
		[TypeFilter(typeof(PermissionCheckFilter))]
		public IActionResult Get([FromServices] IHelloDomain helloDomain)
		{
			return Ok(helloDomain.SayHello());
		}

		[HttpPut]
		[Authorize]
		[TypeFilter(typeof(PermissionCheckFilter))]
		public IActionResult Put(
			[FromServices] IHelloDomain helloDomain,
			string param1,
			DateTime param2,
			decimal param3)
		{
			return Ok(helloDomain.SayHello(param1, param2, param3));
		}

		[HttpPost]
		[Authorize]
		[TypeFilter(typeof(PermissionCheckFilter))]
		public IActionResult Post([FromServices] IHelloDomain helloDomain, HelloData helloData)
		{
			return Ok(helloDomain.SayHello(helloData));
		}
	}
}
#endif