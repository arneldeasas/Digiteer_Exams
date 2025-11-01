using Application.TaskManager.DataTransferObjects.Task;
using Application.TaskManager.Exceptions;
using Application.TaskManager.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using task_manager_api.Controllers;
namespace TaskManager.API
{
	[Route("tasks")]
	[ApiController]
	public class TasksController(ITaskUc Uc) : ControllerBase
	{
		[HttpPost("create-task")]
		public async Task<IActionResult> CreateTask([FromBody] TaskCreateFormDTO dto)
		{
			await Uc.CreateTask(dto);

			return Ok();
		}
		[HttpPost("start-task/{id}")]
		public async Task<IActionResult> StartTask(int id)
		{
			await Uc.StartTask(id);

			return Ok();
		}
		[HttpPost("complete-task/{id}")]
		public async Task<IActionResult> CompleteTask(int id)
		{
			await Uc.CompleteTask(id);

			return Ok();
		}
		[HttpPost("delete-task/{id}")]
		public async Task<IActionResult> DeleteTask(int id)
		{
			await Uc.DeleteTask(id);

			return Ok();
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTask(int id)
		{
			var dto = await Uc.GetTask(id);
			if (dto == null) throw new ItemNotFoundException();

			return Ok(dto);
		}
		[HttpGet("all/{userId}")]
		public async Task<IActionResult> GetUserTasks(int userId)
		{
			var dto = await Uc.GetAllUserTasks(userId);

			return Ok(new SuccessResponse<IEnumerable<TaskListDTO>> { Data = dto });
		}
		//[HttpGet]
		//public async Task<IActionResult> Get()
		//{

		//    var tasks = await _context.Tasks.ToListAsync();
		//    return Ok(tasks);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Create([FromBody] TaskItem task)
		//{

		//    _context.Tasks.Add(task);
		//    await _context.SaveChangesAsync();
		//    return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
		//}

		//[HttpPut("{id}")] 
		//public async Task<IActionResult> Update(int id, [FromBody] TaskItem updated)
		//{
		//    var task = await _context.Tasks.FindAsync(id);
		//    if (task == null) return NotFound();

		//    task.Title = updated.Title;
		//    task.IsDone = updated.IsDone;
		//    await _context.SaveChangesAsync();

		//    return Ok(task);
		//}

		//[HttpDelete("{id}")]
		//public async Task<IActionResult> Delete(int id)
		//{
		//    var task = await _context.Tasks.FindAsync(id);
		//    if (task == null) return NotFound();

		//    _context.Tasks.Remove(task);
		//    await _context.SaveChangesAsync();

		//    return NoContent();
		//}
	}
}
