namespace Application.TaskManager.DataTransferObjects.Task;

public record TaskFormDTO
{
	public int Id { get; set; }
	public string Title { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public DateTime StartDate { get; init; }
	public DateTime DueDate { get; init; }
	public int UserId { get; init; }
}
