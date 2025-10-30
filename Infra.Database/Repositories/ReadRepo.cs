using Application.TaskManager.Repositories;
using Infra.Database.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Database.Repositories;

internal class ReadRepo(AppDbContext Context) : IReadRepo
{
	public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
	{
		return await Context.Set<T>().AnyAsync(predicate);
	}

	public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, bool track = false) where T : class
	{
		var queryDI = Context.Set<T>().AsQueryable();
		if (!track) queryDI = queryDI.AsNoTracking();
		return await queryDI.FirstOrDefaultAsync(predicate);
	}

	public async Task<List<T>> GetAllAsync<T>(bool track = false) where T : class
	{
		var queryDI = Context.Set<T>().AsQueryable();
		if (!track) queryDI = queryDI.AsNoTracking();
		return await queryDI.ToListAsync();
	}

	public async Task<int> GetCountAsync<T>(Expression<Func<T, bool>> predicate) where T : class
	{
		return await Context.Set<T>().CountAsync(predicate);
	}

	public async Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate, bool track = false) where T : class
	{
		var queryDI = Context.Set<T>().Where(predicate);
		if (!track) queryDI = queryDI.AsNoTracking();
		return await queryDI.ToListAsync();
	}

	public async Task<List<TProjection>> GetManyProjectedAsync<TEntity, TProjection>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjection>> selector) where TEntity : class
	{
		return await Context.Set<TEntity>().Where(predicate).Select(selector).ToListAsync();
	}

	public async Task<TProjection?> GetProjectedAsync<TEntity, TProjection>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjection>> selector) where TEntity : class
	{
		return await Context.Set<TEntity>().Where(predicate).Select(selector).FirstOrDefaultAsync();
	}
}
