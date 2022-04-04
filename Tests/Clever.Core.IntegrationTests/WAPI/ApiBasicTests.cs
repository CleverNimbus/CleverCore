using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Clever.Core.IntegrationTests.WAPI
{
	public class ApiBasicTests
	{
		//https://medium.com/swlh/tdd-and-exception-handling-with-xunit-in-asp-net-core-f9ffe5dde800
		//[Fact]
		//public async Task Returns_OpenWeatherException_When_Called_With_Bad_Argument()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.NotFoundResponse,
		//		HttpStatusCode.NotFound);
		//	var sut = new OpenWeatherService(opts, clientFactory); var result = await Assert.ThrowsAsync<OpenWeatherException>(() => sut.GetFiveDayForecastAsync("Westeros"));
		//	Assert.Equal(404, (int)result.StatusCode);
		//}

		//[Fact]
		//public async Task Returns_OpenWeatherException_When_Unauthorized()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.UnauthorizedResponse,
		//		HttpStatusCode.Unauthorized);
		//	var sut = new OpenWeatherService(opts, clientFactory); var result = await Assert.ThrowsAsync<OpenWeatherException>(() => sut.GetFiveDayForecastAsync("Chicago"));
		//	Assert.Equal(401, (int)result.StatusCode);
		//}

		//[Fact]
		//public async Task Returns_OpenWeatherException_On_OpenWeatherInternalError()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.InternalErrorResponse,
		//		HttpStatusCode.InternalServerError);
		//	var sut = new OpenWeatherService(opts, clientFactory); var result = await Assert.ThrowsAsync<OpenWeatherException>(() => sut.GetFiveDayForecastAsync("New York"));
		//	Assert.Equal(500, (int)result.StatusCode);
		//}

		//[Fact]
		//public async Task Returns_400_Result_When_Missing_Location()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.NotFoundResponse);
		//	var service = new OpenWeatherService(opts, clientFactory);
		//	var sut = new WeatherForecastController(new NullLogger<WeatherForecastController>(), service); var result = await sut.Get(String.Empty) as ObjectResult; Assert.Equal(400, result.StatusCode);
		//}

		//[Fact]
		//public async Task Returns_BadRequestResult_When_Location_Not_Found()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.NotFoundResponse,
		//		HttpStatusCode.NotFound);
		//	var service = new OpenWeatherService(opts, clientFactory);
		//	var sut = new WeatherForecastController(new NullLogger<WeatherForecastController>(), service); var result = await sut.Get("Westworld") as ObjectResult; Assert.Contains("not found", result.Value.ToString());
		//	Assert.Equal(400, result.StatusCode);
		//}

		//[Fact]
		//public async Task Returns_OpenWeatherException_When_Unauthorized()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.UnauthorizedResponse,
		//		HttpStatusCode.Unauthorized);
		//	var sut = new OpenWeatherService(opts, clientFactory); var result = await Assert.ThrowsAsync<OpenWeatherException>(() => sut.GetFiveDayForecastAsync("Chicago"));
		//	Assert.Equal(401, (int)result.StatusCode);
		//}

		//[Fact]
		//public async Task Returns_500_When_Api_Returns_Error()
		//{
		//	var opts = OptionsBuilder.OpenWeatherConfig();
		//	var clientFactory = ClientBuilder.OpenWeatherClientFactory(OpenWeatherResponses.UnauthorizedResponse,
		//		HttpStatusCode.Unauthorized);
		//	var service = new OpenWeatherService(opts, clientFactory);
		//	var sut = new WeatherForecastController(new NullLogger<WeatherForecastController>(), service); var result = await sut.Get("Rio de Janeiro") as ObjectResult; Assert.Contains("Error response from OpenWeatherApi: Unauthorized", result.Value.ToString());
		//	Assert.Equal(500, result.StatusCode);
		//}
	}
}