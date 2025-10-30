using Application.TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options) { }
	public DbSet<User> Users => Set<User>();
	public DbSet<TaskItem> Tasks => Set<TaskItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>()
			.HasMany(u => u.Tasks)
			.WithOne(t => t.User)
			.HasForeignKey(t => t.UserId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
