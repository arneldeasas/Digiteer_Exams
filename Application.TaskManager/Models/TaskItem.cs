namespace Application.TaskManager.Models;

public class TaskItem
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public DateTime? StartDate { get; set; }
	public DateTime DueDate { get; set; }
	public DateTime? FinishedDate { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime UpdatedDate { get; set; }
	public bool Archived { get; set; } = false;
	public int UserId { get; set; }
	public User User { get; set; } = null!;
}
