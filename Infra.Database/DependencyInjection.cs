using Application.TaskManager.Repositories;
using Infra.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database;

public static class DependencyInjection
{
	public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services)
	{
		services.AddScoped<ICommandRepo, CommandRepo>();
		services.AddScoped<IReadRepo, ReadRepo>();
		return services;
	}
}
