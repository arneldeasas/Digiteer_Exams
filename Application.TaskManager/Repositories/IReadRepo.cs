using System.Linq.Expressions;

namespace Application.TaskManager.Repositories;

public interface IReadRepo
{
	Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, bool track = false)
		where T : class;

	Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate, bool track = false)
		where T : class;

	Task<List<T>> GetAllAsync<T>(bool track = false)
		where T : class;

	Task<int> GetCountAsync<T>(Expression<Func<T, bool>> predicate)
		where T : class;

	Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate)
		where T : class;

	Task<List<TProjection>> GetManyProjectedAsync<TEntity, TProjection>(
	   Expression<Func<TEntity, bool>> predicate,
	   Expression<Func<TEntity, TProjection>> selector
	)
	   where TEntity : class;

	Task<TProjection?> GetProjectedAsync<TEntity, TProjection>(
	   Expression<Func<TEntity, bool>> predicate,
	   Expression<Func<TEntity, TProjection>> selector
	)
		where TEntity : class;
}
