namespace Application.TaskManager.Services.Interfaces;

internal interface IPasswordService
{
	string HashPassword(string password);
	bool VerifyPassword(string hashedPassword, string providedPassword);
}
