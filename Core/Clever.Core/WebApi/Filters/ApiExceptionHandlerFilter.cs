using Clever.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace Clever.Core.WebApi.Filters
{
	public class ApiExceptionHandlerFilter : IActionFilter, IOrderedFilter
	{
		private readonly ILogger<ApiExceptionHandlerFilter> _logger;

		public int Order { get; } = int.MaxValue - 88;

		public ApiExceptionHandlerFilter(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<ApiExceptionHandlerFilter>();
		}		

		public void OnActionExecuting(ActionExecutingContext context)
		{ }

		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Exception is BusinessLogicBrokenException exception)
			{
				var dictionary = new ModelStateDictionary();
				dictionary.AddModelError("Message", exception.Message);
				_ = dictionary.Keys.Append("errors");
				context.Result = new BadRequestObjectResult(dictionary);
				context.ExceptionHandled = true;
				_logger.LogError(exception, "BL Error");
				return;
			}

			if (context.Exception is WrongCallException ex_)
			{
				var dictionary = new ModelStateDictionary();
				dictionary.AddModelError("Message", ex_.Message);
				_ = dictionary.Keys.Append("errors");
				context.Result = new BadRequestObjectResult(dictionary);
				context.ExceptionHandled = true;
				_logger.LogError(ex_, "Wrong call Error");
				return;
			}			

			if (context.Exception is Exception ex)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
				context.ExceptionHandled = true;

				_logger.LogError(ex, "General Error");

				return;
			}
		}
	}
}