namespace Application.TaskManager.DataTransferObjects.User;

public record SignInFormDTO
{
	public string UserName { get; init; } = string.Empty;
	public string Password { get; init; } = string.Empty;
}
