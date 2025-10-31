using Microsoft.Extensions.Logging;

namespace Application.TaskManager.UseCases;

internal class UseCaseHandler(ILogger Logger)
{
	public async Task<T> HandleUseCaseAsync<T>(Func<Task<T>> useCaseAction, string useCaseName, params object[] args )
	{
		try
		{
			Logger.LogInformation("Started handling: {UseCaseName}", useCaseName);
			Logger.LogDebug("Started handling: {UseCaseName} @{Arguments}", useCaseName,args);

			var result = await useCaseAction();

			Logger.LogInformation("Completed handling: {UseCaseName} ", useCaseName);
			Logger.LogDebug("Completed handling: {UseCaseName} @{Result}", useCaseName,result);
			return result;
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error occurred in use case: {UseCaseName}", useCaseName);
			throw;
		}
	}
	public async Task HandleUseCaseAsync(Func<Task> useCaseAction, string useCaseName, params object[] args)
	{
		try
		{
			Logger.LogInformation("Started handling: {UseCaseName}", useCaseName);
			Logger.LogDebug("Started handling: {UseCaseName} @{Arguments}", useCaseName, args);

			await useCaseAction();

			Logger.LogInformation("Completed handling: {UseCaseName} ", useCaseName);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error occurred in use case: {UseCaseName}", useCaseName);
			throw;
		}
	}
}
