using Application.TaskManager.DataTransferObjects.Task;

namespace Application.TaskManager.UseCases.Interfaces;

public interface ITaskUc
{
	Task CreateTask(TaskCreateFormDTO form);
	Task StartTask(int taskId);
	Task CompleteTask(int taskId);
	Task DeleteTask(int taskId);
	Task<TaskDTO?> GetTask(int taskId);
	Task<IEnumerable<TaskListDTO>> GetAllUserTasks(int userId);
}
