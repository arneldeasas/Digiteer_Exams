using Application.TaskManager.DataTransferObjects.User;
using Application.TaskManager.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace task_manager_api.Controllers
{
	[Route("user")]
	[ApiController]
	public class UserController(IUserUc Uc) : Controller
	{
		[HttpPost("sign-up")]
		public async Task<IActionResult> SignUp([FromBody] UserFormDTO dto)
		{
			await Uc.SignUpUser(dto);
			return Ok();
		}

		[HttpPost("sign-in")]
		public async Task<IActionResult> SignIn([FromBody] SignInFormDTO dto)
		{
			await Uc.SignInUser(dto);
			return Ok();
		}

	}
}
