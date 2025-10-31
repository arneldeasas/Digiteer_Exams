using Application.TaskManager.Services.Interfaces;

namespace Application.TaskManager.Services.Implementations;

public class PasswordService : IPasswordService
{
	public string HashPassword(string password)
	{
		return BCrypt.Net.BCrypt.HashPassword(password);
	}

	public bool VerifyPassword(string hashedPassword, string providedPassword)
	{
		return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
	}
}
