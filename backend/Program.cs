using Infra.Database.Data;
using Infra.Database;
using Application.TaskManager;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationDependencies();
builder.Services.AddDatabaseDependencies();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		//This should be configured to allow specific origins of the frontend application in production or any consumer interfaces, but for demo purposes, we allow all.
		policy.AllowAnyOrigin()
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

