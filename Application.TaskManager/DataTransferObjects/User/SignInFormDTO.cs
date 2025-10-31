using System.ComponentModel.DataAnnotations;

namespace Application.TaskManager.DataTransferObjects.User;

public record SignInFormDTO
{
	[Required]
	public string UserName { get; init; } = string.Empty;
	[Required]
	public string Password { get; init; } = string.Empty;
}
