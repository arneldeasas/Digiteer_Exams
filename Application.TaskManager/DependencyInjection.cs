using Application.TaskManager.Services.Implementations;
using Application.TaskManager.Services.Interfaces;
using Application.TaskManager.UseCases;
using Application.TaskManager.UseCases.Implementations;
using Application.TaskManager.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.TaskManager;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
	{
		services.AddScoped<UseCaseHandler>();

		services.AddScoped<IPasswordService, PasswordService>();

		services.AddScoped<IUserUc, UserUc>();
		services.AddScoped<ITaskUc, TaskUc>();

		return services;
	}
}
