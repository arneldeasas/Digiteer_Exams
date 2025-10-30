using Application.TaskManager.DataTransferObjects.User;
using Application.TaskManager.UseCases.Interfaces;

namespace Application.TaskManager.UseCases.Implementations;

internal class UserUc : IUserUc
{
	public Task SignInUser(SignInFormDTO form)
	{
		throw new NotImplementedException();
	}

	public Task SignUpUser(UserFormDTO form)
	{
		throw new NotImplementedException();
	}
}
