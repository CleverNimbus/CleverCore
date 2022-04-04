using Clever.Core.Service.Factories;
using Clever.Core.WebApi.Authentication.Anonymous;
using Clever.Core.WebApi.Authentication.JWT.Contracts;
using Clever.Core.WebApi.Authentication.JWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Clever.Core.WebApi.Authorization.Checking.Contracts;
using Clever.Core.WebApi.Authorization.Checking.Services;

#if !SINGLE_ENTRYPOINT
using Clever.Example.Domain.Contracts;
using Clever.Example.Domain.Implementation;
using Clever.Core.Persistence.DB.Services;
using Clever.Core.Persistence.DB;
#else
using Clever.Core.Service;
#endif

var builder = WebApplication.CreateBuilder(args);

//Check if configuration dictates to use JWT Authentication
var useJwt = bool.Parse(builder.Configuration["Jwt:UseJwt"]);

var ePointCManager = new EntryPointsCacheManager();
builder.Services.AddSingleton<IEntryPointsCacheManager>(ePointCManager);

builder.Services.AddSingleton<IPermissionChecker, AuthorizeAllPermissionChecker>();

//TODO: put to work the api exception handler
builder.Services.AddControllers(); //options => options.Filters.Add(new ApiExceptionHandlerFilter())

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
if (useJwt)
{
	builder.Services.AddSingleton<ITokenService>(new TokenService());
	builder.Services.AddSingleton<IUserRepositoryService>(new HardCodedUserRepositoryService());

	builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
	{
		opt.TokenValidationParameters = new()
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Issuer"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});
}
else
{
	builder.Services.AddSingleton<IAuthorizationHandler, AnonymousAuthorizationHandler>();
}

#if SINGLE_ENTRYPOINT
	ServiceOrchestrator.Instance = new ServiceOrchestrator
	{
		ServiceCollection = builder.Services
	};
	ServiceOrchestrator.Instance.AddInternalServices();

	builder.Services.ConfigureFactory(builder.Configuration["Core:ExplorationFolder"], builder.Configuration["Core:ExplorationPattern"], ePointCManager);
#else
//TODO: Try to get started the ConfigureFactory for this option too
	builder.Services.AddLogging();
	builder.Services.AddScoped<IDatabaseService, LiteDBService>();
	builder.Services.AddScoped<IHelloDomain, HelloDomain>();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (useJwt)
{
	app.UseAuthentication();
}
app.UseAuthorization();

app.MapControllers();

app.Run();