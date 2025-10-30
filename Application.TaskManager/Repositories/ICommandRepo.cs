namespace Application.TaskManager.Repositories;

public interface ICommandRepo
{
	void Update<T>(T item) where T : class;
	Task AddAsync<T>(T item) where T : class;
	Task AddManyAsync<T>(List<T> item) where T : class;
	Task SaveChangesAsync();
	Task BeginTransactionAsync();
	Task RollbackAsync();
	Task CommitAsync();
	void UntrackAll();
}
