using Application.TaskManager.DataTransferObjects.Task;

namespace Application.TaskManager.UseCases.Interfaces;

public interface ITaskUc
{
	Task CreateTask(TaskFormDTO form);
	Task StartTask(int taskId);
	Task CompleteTask(int taskId);
	Task DeleteTask(int taskId);
}
