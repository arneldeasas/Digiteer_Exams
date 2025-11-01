using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace task_manager_api.Controllers;

public class ControllerWrapper :ControllerBase
{
	async Task<IActionResult> ExecuteRequestAsync(Func<Task> action)
	{
		try
		{
			await action();
			return Ok();
		}
		catch (ApplicationException ex)
		{
			return BadRequest(ex);
		}
		catch (Exception ex)
		{
			return Problem(ex.InnerException?.Message ?? "Server error occured");
		}
	}
	async Task<IActionResult> ExecuteRequestAsync<T>(Func<Task<T>> action)
	{
		try
		{
			var result = await action();
			return Ok(result);
		}
		catch (ApplicationException ex)
		{
			return BadRequest(ex);
		}
		catch (Exception ex)
		{
			return Problem(ex.InnerException?.Message ?? "Server error occured");
		}
	}
}
