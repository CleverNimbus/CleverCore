using Clever.Core.Exceptions;
using Clever.Core.Results;
using Clever.Example.Domain.Contracts;
using Clever.Example.Models.DTOs;
using Clever.Example.Models.Entities;
using System.Linq;

namespace Clever.Example.Tests
{
	public class HelloDomainTests
	{
		private readonly IHelloDomain _d;

		public HelloDomainTests(IHelloDomain d) => _d = d;

		[Fact]
		public void SayHelloWorks()
		{
			Assert.NotNull(_d.SayHello());
			Assert.IsType<BackEndOperationResult>(_d.SayHello());
			Assert.Equal(5, _d.SayHello().OperationResultData.Count());
		}

		[Fact]
		public void BookMantainsValidationLogic()
		{
			var exception = Record.Exception(() =>
			{
				var book = new Book(string.Empty);
			});
			Assert.IsType<BusinessLogicBrokenException>(exception);
		}

		[Fact]
		public void SayHelloWithDataWorks()
		{
			var result = _d.SayHello(new HelloData { Id = 233, Name = "Book book" });

			Assert.NotNull(result);
			Assert.IsType<BackEndOperationResult>(result);
			Assert.True(result.OperationResultData.Any());
			Assert.IsType<HelloData>(result.OperationResultData.First());
			Assert.Equal("Book book", ((HelloData)result.OperationResultData.First()).Name);
		}
	}
}