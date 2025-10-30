using Application.TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }
		public DbSet<User> Users => Set<User>();
		public DbSet<TaskItem> Tasks => Set<TaskItem>();
	}
}
