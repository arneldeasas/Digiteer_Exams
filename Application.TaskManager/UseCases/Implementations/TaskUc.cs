using Application.TaskManager.DataTransferObjects.Task;
using Application.TaskManager.UseCases.Interfaces;
using System.Threading.Tasks;

namespace Application.TaskManager.UseCases.Implementations;

internal class TaskUc(UseCaseHandler Handler) : ITaskUc
{
	public Task CreateTask(TaskFormDTO form)=>
		Handler.HandleUseCaseAsync(async () =>
		{

		}, nameof(CompleteTask), form);

	public Task CompleteTask(int taskId)=>
		Handler.HandleUseCaseAsync(async () =>
		{

		}, nameof(CompleteTask), taskId);

	public Task DeleteTask(TaskFormDTO form)
	{
		throw new NotImplementedException();
	}

	public Task StartTask(int taskId)
	{
		throw new NotImplementedException();
	}
}
