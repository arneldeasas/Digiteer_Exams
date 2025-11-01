using Application.TaskManager.Exceptions;
using System.Net;
using System.Text.Json;
using ApplicationException = Application.TaskManager.Exceptions.ApplicationException;

public class ExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (ApplicationException ex)
		{
			//Application exceptions are bad request by default. 
			//We still want to throw specific status code within the 4** range if needed so this pattern can be extended.
			var statusCode = ex switch
			{
				ItemNotFoundException => HttpStatusCode.NotFound, // 404
				_ => HttpStatusCode.BadRequest
			};
			await HandleExceptionAsync(context, ex, statusCode);
		}
		catch (Exception ex)
		{
			//Unhandled exceptions are server errors
			await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError); // 500
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode status)
	{

		var response = new FailedResponse
		{
			ErrorMessage = exception.Message,
			Type = exception.GetType().Name,
			StatusCode = (int)status
		};

		var payload = JsonSerializer.Serialize(response);

		context.Response.StatusCode = (int)status;
		context.Response.ContentType = "application/json";
		//context.Response.StatusCode = (int)statusCode;

		return context.Response.WriteAsync(payload);
	}
}

#region Reponses Models
//This is to standardize responses from the API
public class ResponseBase
{
	public bool Success { get; protected set; }
}
public class SuccessResponse : ResponseBase
{
	public SuccessResponse()
	{
		base.Success = true;
	}
}
public class SuccessResponse<T> : ResponseBase
{
	public SuccessResponse()
	{
		base.Success = true;
	}
	public T? Data { get; set; } = default;
}
public class FailedResponse : ResponseBase
{
	public FailedResponse()
	{
		base.Success = false;
	}
	public string ErrorMessage { get; set; } = string.Empty;
	public string Type { get; set; } = string.Empty;
	public int StatusCode { get; set; }
}
#endregion
