﻿namespace Application.TaskManager.DataTransferObjects.User;

public record UserFormDTO
{
	public string UserName { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string Password { get; init; } = string.Empty;
}
