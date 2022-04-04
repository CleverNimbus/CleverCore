using Clever.Example.Repository.Contracts;

namespace Clever.Example.Tests
{
	public class AuthorRepositoryTests
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorRepositoryTests(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}
		
		[Fact]
		public void RepositoryIsResolved()
		{
			Assert.NotNull(_authorRepository);
		}

		[Fact]
		public void AuthorCountIs1()
		{
			//var mockedDBFactory = new Mock<IDatabaseService>();
			//mockedDBFactory.Setup(t => t.Count<Author>()).Returns(1);
			//var descriptor = new ServiceDescriptor(typeof(IDatabaseService), mockedDBFactory.GetType(), ServiceLifetime.Transient);

			Assert.Equal(1, _authorRepository.Count());			
		}
	}
}