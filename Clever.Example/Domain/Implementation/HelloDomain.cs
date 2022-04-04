using Clever.Core.Domain;
using Clever.Core.Results;
using Clever.Example.Domain.Contracts;
using Clever.Example.Models.DTOs;

namespace Clever.Example.Domain.Implementation
{
	public class HelloDomain : CoreDomain, IHelloDomain
	{
		public BackEndOperationResult SayHello()
		{
			return new BackEndOperationResult
			{
				OperationResultData = new string[] { "Hello", "Hello", "Hello", "Hello", "Hello" },
				OperationResultSuccess = true
			};
		}

		public BackEndOperationResult SayHello(string param1, DateTime param2, decimal? param3)
		{
			return new BackEndOperationResult
			{
				OperationResultData = new object[] { param1, param2, param3 ?? 0m },
				OperationResultSuccess = true
			};
		}

		public BackEndOperationResult SayHello(HelloData helloData)
		{
			return new BackEndOperationResult
			{
				OperationResultData = new object[] { helloData },
				OperationResultSuccess = true
			};
		}
	}
}