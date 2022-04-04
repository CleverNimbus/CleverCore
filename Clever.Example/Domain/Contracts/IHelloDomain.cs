using Clever.Core.Domain;
using Clever.Core.Results;
using Clever.Example.Models.DTOs;

namespace Clever.Example.Domain.Contracts
{
	public interface IHelloDomain : ICoreDomain
	{
		BackEndOperationResult SayHello();

		BackEndOperationResult SayHello(string param1, DateTime param2, decimal? param3);

		BackEndOperationResult SayHello(HelloData helloData);
	}
}