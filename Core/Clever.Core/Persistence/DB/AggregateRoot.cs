namespace Clever.Core.Persistence.DB
{
	/// <summary>
	/// From DDD, identifies an object treated as AgregateRoot
	/// </summary>
	public record AggregateRoot
	{
		public int Id { get; set; }
	}
}