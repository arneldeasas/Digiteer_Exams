using Application.TaskManager.Exceptions;
using Application.TaskManager.Repositories;
using Infra.Database.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Infra.Database.Repositories;

internal class CommandRepo(AppDbContext Context, ILogger<CommandRepo> Logger) : ICommandRepo
{
	IDbContextTransaction? _transaction;
	public async Task BeginTransactionAsync()
	{
		_transaction = await Context.Database.BeginTransactionAsync();
	}

	public async Task CommitAsync()
	{
		try
		{
			if (_transaction is not null)
			{
				await _transaction.CommitAsync();
				await _transaction.DisposeAsync();
				_transaction = null;
			}
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error during transaction commit");
			throw new DatabaseException("Error during transaction commit", ex);
		}
	}

	public async Task RollbackAsync()
	{
		try
		{
			if (_transaction is not null)
			{
				await _transaction.RollbackAsync();
				await _transaction.DisposeAsync();
			}
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error during transaction rollback");
			throw new DatabaseException("Error during transaction rollback", ex);
		}
	}

	public async Task SaveChangesAsync()
	{
		try
		{
			await Context.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error saving changes async.");
			throw new DatabaseException("Error saving changes async.", ex);
		}
	}

	public async Task AddManyAsync<T>(List<T> items) where T : class
	{
		try
		{
			await Context.AddRangeAsync(items);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, $"Error adding many entities of type {typeof(T).Name}");
			throw new DatabaseException(
				$"Error adding many entities of type {typeof(T).Name}. Message: {ex.Message}",
				ex
			);
		}
	}

	public void UpdateMany<T>(List<T> items) where T : class
	{
		try
		{
			Context.UpdateRange(items);
		}
		catch (Exception e)
		{
			Logger.LogError(e, $"Error updating many entities of type {typeof(T).Name}");
			throw new DatabaseException(
				$"Error updating entities of type {typeof(T).Name}. Message: {e.Message}",
				e
			);
		}
	}

	public void Update<T>(T item) where T : class
	{
		try
		{
			Context.Update(item);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, $"Error updating entity of type {typeof(T).Name}");
			throw new DatabaseException(
				$"Error updating entity of type {typeof(T).Name}. Message: {ex.Message}",
				ex
			);
		}
	}

	public async Task AddAsync<T>(T item) where T : class
	{
		try
		{
			await Context.Set<T>().AddAsync(item);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, $"Error adding entity async of type {typeof(T).Name}");
			throw new DatabaseException(
				$"Error adding entity async of type {typeof(T).Name}. Message: {ex.Message}",
				ex
			);
		}
	}

	public void UntrackAll()
	{
		try
		{
			Context.ChangeTracker.Clear();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error un-tracking entities");
			throw new DatabaseException(
				$"Error un-tracking entities. Message: {ex.Message}",
				ex
			);
		}
	}
}
