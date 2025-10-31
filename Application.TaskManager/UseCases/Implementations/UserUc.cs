using Application.TaskManager.DataTransferObjects.User;
using Application.TaskManager.Models;
using Application.TaskManager.Repositories;
using Application.TaskManager.UseCases.Interfaces;
using Mapster;

namespace Application.TaskManager.UseCases.Implementations;

internal class UserUc(UseCaseHandler Handler, ICommandRepo Command, IReadRepo Read) : IUserUc
{
	public Task SignInUser(SignInFormDTO form) =>
		Handler.HandleUseCaseAsync(async () =>
		{
			TaskItem taskItem = form.Adapt<TaskItem>();
			await Command.AddAsync(taskItem);

			await Command.SaveChangesAsync();

			Command.UntrackAll();

		}, nameof(SignInUser), form);

	public Task SignUpUser(UserFormDTO form)
	{
		throw new NotImplementedException();
	}

}
