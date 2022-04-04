using Clever.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Clever.Core.Extensions
{
	/// <summary>
	/// HttpRequest Extensions
	/// </summary>
	public static class RequestExtensions
	{
		/// <summary>
		/// Process the request url to return it's parts
		/// </summary>
		/// <param name="request">An HttpRequest</param>
		/// <returns>Array of URL items without trails</returns>
		/// <exception cref="WrongRequestedRouteException">Unable to obtain Url from Request</exception>
		/// <exception cref="WrongLengthRequestedRouteException">All url request must contain at least 3 items</exception>
		public static string[] ProcessRequest(this HttpRequest request)
		{
			string[] result;

			var requestedRoute = request.GetDisplayUrl();

			if (requestedRoute == null || string.IsNullOrWhiteSpace(requestedRoute.ToString()))
			{
				throw new WrongRequestedRouteException();
			}

			result = requestedRoute.ToString().Split('/');
			if (result.Length < 3)
			{
				throw new WrongLengthRequestedRouteException();
			}

			return result;
		}
	}
}