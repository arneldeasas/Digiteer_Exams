namespace Application.TaskManager.Models;

public class User
{
	public int Id { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public bool Archived { get; set; } = false;
	public DateTime CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
	public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
