using Clever.Core.WebApi.Authentication.JWT.Contracts;
using Clever.Core.WebApi.Authentication.JWT.Entities;

namespace Clever.Api
{
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ITokenService _tokenService;
		private readonly IUserRepositoryService _userRepositoryService;
		private readonly IConfiguration _configuration;

		public LoginController([FromServices] ITokenService tokenService,
			[FromServices] IUserRepositoryService userRepositoryService,
			[FromServices] IConfiguration configuration)
		{
			_tokenService = tokenService;
			_userRepositoryService = userRepositoryService;
			_configuration = configuration;
		}

		[AllowAnonymous]
		[Route("api/login")]
		[HttpGet]
		public async Task<IActionResult> LoginAsync()
		{
			var userModel = await Request.ReadFromJsonAsync<UserModel>();
			if (userModel == null ||
				string.IsNullOrWhiteSpace(userModel.UserName) ||
				string.IsNullOrWhiteSpace(userModel.Password))
			{
				return NotFound();
			}

			var userDto = _userRepositoryService.GetUser(userModel);
			if (userDto == null)
			{
				return Unauthorized();
			}

			var expiryDuration = TimeSpan.Parse(_configuration["Jwt:TokenExpiryDuration"]);
			var token = _tokenService.BuildToken(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], userDto, expiryDuration);
			return Ok(new
			{
				token,
				user = userModel.UserName
			});
		}
	}
}