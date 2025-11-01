using Application.TaskManager.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Application.TaskManager.DataTransferObjects.Task;

public record TaskCreateFormDTO
{
	public int Id { get; set; }

	[Required]
	public string Title { get; init; } = string.Empty;

	[Required]
	public string Description { get; init; } = string.Empty;

	[Required]
	[DateNotInPast]
	public DateTime DueDate { get; init; }

	public int UserId { get; init; }
}
