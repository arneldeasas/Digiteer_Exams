using Application.TaskManager.DataTransferObjects.User;
using Application.TaskManager.Models;
using Application.TaskManager.Repositories;
using Application.TaskManager.Services.Interfaces;
using Application.TaskManager.UseCases.Interfaces;
using Mapster;

namespace Application.TaskManager.UseCases.Implementations;

internal class UserUc(UseCaseHandler Handler, ICommandRepo Command, IReadRepo Read,IPasswordService PasswordService) : IUserUc
{
	public Task SignInUser(SignInFormDTO form) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			var user = await Read.FirstOrDefaultAsync<User>(x => x.UserName.Equals(form.UserName, StringComparison.CurrentCultureIgnoreCase));
			if (user is null) throw new ApplicationException("Invalid username or password");

			var passwordValid = PasswordService.VerifyPassword(form.Password, user.PasswordHash);
			if (!passwordValid) throw new ApplicationException("Invalid username or password");

		}, nameof(SignInUser), form);

	public Task SignUpUser(UserFormDTO form) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			//Check for existing user
			var userAlreadyExists= await Read.ExistsAsync<User>(x=>x.UserName.Equals(form.UserName, StringComparison.CurrentCultureIgnoreCase));
			if(userAlreadyExists) throw new ApplicationException("User with the same username already exists");

			User user = form.Adapt<User>();
			user.PasswordHash = PasswordService.HashPassword(form.Password);

			await Command.AddAsync(user);

			await Command.SaveChangesAsync();

			Command.UntrackAll();

		}, nameof(SignInUser), form);
}
