using Application.TaskManager.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Application.TaskManager.DataTransferObjects.Task;

public record TaskDTO
{
	public int Id { get; set; }
	public string Title { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public DateTime? StartDate { get; init; }
	public DateTime? FinishedDate { get; init; }
	public DateTime DueDate { get; init; }
	public bool Archived { get; init; }
	public int UserId { get; init; }
}
