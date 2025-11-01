namespace Application.TaskManager.DataTransferObjects.Task;

public record TaskListDTO
{
	public int Id { get; init; }
	public string Title { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public string TaskStatus { get; set; } = string.Empty;	 
	public DateTime CreatedDate { get; init; }
	public DateTime? StartDate { get; init; }
	public DateTime? FinishedDate { get; init; }
	public DateTime? DueDate { get; init; }
}
