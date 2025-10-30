using Application.TaskManager.DataTransferObjects.User;

namespace Application.TaskManager.UseCases.Interfaces;

public interface IUserUc
{
	Task SignUpUser(UserFormDTO form);
	Task SignInUser(SignInFormDTO form);
}
