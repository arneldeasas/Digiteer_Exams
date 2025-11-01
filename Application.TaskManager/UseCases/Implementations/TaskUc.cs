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
	public Task CreateTask(TaskCreateFormDTO form) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			var userExists = await Read.ExistsAsync<User>(x => x.Id == form.UserId);
			if (!userExists) throw new ApplicationException("User not found");

			TaskItem taskItem = form.Adapt<TaskItem>();
			taskItem.CreatedDate = DateTime.UtcNow;

			await Command.AddAsync(taskItem);

			await Command.SaveChangesAsync();

			Command.UntrackAll();
		}, nameof(CompleteTask), form);

	public Task CompleteTask(int taskId) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			var taskItem = await Read.FirstOrDefaultAsync<TaskItem>(x => x.Id == taskId, track: true);
			if (taskItem is null) throw new ApplicationException("Task not found");

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

	public Task<TaskDTO?> GetTask(int taskId)=>
		Handler.HandleUseCaseAsync(async () =>
		{
			var dto = await Read.GetProjectedAsync<TaskItem,TaskDTO>(
				x=> x.Id == taskId,
				x=> new TaskDTO
				{
					UserId = x.UserId,
					Title = x.Title,
					Description = x.Description,
					DueDate = x.DueDate,
					Id = x.Id,
					StartDate = x.StartDate,
					FinishedDate = x.FinishedDate,
					Archived = x.Archived,
				});

			return dto;
		}, nameof(GetTask), taskId);

	public Task<IEnumerable<TaskListDTO>> GetAllUserTasks(int userId) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			var dto = await Read.GetManyProjectedAsync<TaskItem, TaskListDTO>(
				x => x.UserId == userId,
				x => new TaskListDTO
				{
					Title = x.Title,
					Description = x.Description,
					DueDate = x.DueDate,
					Id = x.Id,
					StartDate = x.StartDate,
					FinishedDate = x.FinishedDate,
					CreatedDate = x.CreatedDate
				});
			
			foreach(var item in dto)
			{
				item.TaskStatus = item.FinishedDate.HasValue ? "Completed" :
								  item.StartDate.HasValue ? "In Progress" : "Not Started";
			}

			return dto.AsEnumerable();
		}, nameof(GetAllUserTasks), userId);
}
