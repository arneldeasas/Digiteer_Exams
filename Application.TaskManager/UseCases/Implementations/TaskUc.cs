using Application.TaskManager.DataTransferObjects.Task;
using Application.TaskManager.Exceptions;
using Application.TaskManager.Models;
using Application.TaskManager.Repositories;
using Application.TaskManager.UseCases.Interfaces;
using Mapster;
using System.Threading.Tasks;
using ApplicationException = Application.TaskManager.Exceptions.ApplicationException;

namespace Application.TaskManager.UseCases.Implementations;

internal class TaskUc(UseCaseHandler Handler, ICommandRepo Command, IReadRepo Read) : ITaskUc
{
	public Task CreateTask(TaskFormDTO form)=>
		Handler.HandleUseCaseAsync(async () =>
		{
			try
			{
				await Command.BeginTransactionAsync();

				TaskItem taskItem = form.Adapt<TaskItem>();
				await Command.AddAsync(taskItem);

				await Command.SaveChangesAsync();

				Command.UntrackAll();
				await Command.CommitAsync();
			}
			catch (Exception)
			{
				await Command.RollbackAsync();
				throw;
			}

		}, nameof(CompleteTask), form);

	public Task CompleteTask(int taskId)=>
		Handler.HandleUseCaseAsync(async () =>
		{
			var taskItem =  await Read.FirstOrDefaultAsync<TaskItem>(x=>x.Id == taskId,track:true);
			if(taskItem is null) throw new ApplicationException("Task not found");

			taskItem.FinishedDate = DateTime.UtcNow;
			taskItem.UpdatedDate = DateTime.UtcNow;
			await Command.SaveChangesAsync();
			Command.UntrackAll();
		}, nameof(CompleteTask), taskId);

	public Task DeleteTask(int taskId) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			var taskItem = await Read.FirstOrDefaultAsync<TaskItem>(x => x.Id == taskId, track: true);
			if (taskItem is null) throw new ApplicationException("Task not found");

			taskItem.Archived = true;
			taskItem.UpdatedDate = DateTime.UtcNow;

			await Command.SaveChangesAsync();
			Command.UntrackAll();
		}, nameof(DeleteTask), taskId);

	public Task StartTask(int taskId) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			var taskItem = await Read.FirstOrDefaultAsync<TaskItem>(x => x.Id == taskId, track: true);
			if (taskItem is null) throw new ApplicationException("Task not found");

			taskItem.StartDate = DateTime.UtcNow;
			taskItem.UpdatedDate = DateTime.UtcNow;

			await Command.SaveChangesAsync();
			Command.UntrackAll();
		}, nameof(StartTask), taskId);
}
