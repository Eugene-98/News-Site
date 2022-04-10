using Microsoft.EntityFrameworkCore;
using News_Site.Models;

namespace News_Site.Data
{
	public class Context : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<News> News { get; set; }

		public Context(DbContextOptions<Context> options)
		: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string adminRoleName = "admin";
			string userRoleName = "user";

			string adminUsername = "master";
			string adminPassword = "123456";

			Role adminRole = new Role {RoleId = 1, Name = adminRoleName};
			Role userRole = new Role { RoleId = 2, Name = userRoleName};
			User adminUser = new User
				{Id = 1, Username = adminUsername, Password = adminPassword, RoleId = adminRole.RoleId};

			modelBuilder.Entity<Role>().HasData(new Role[] {adminRole, userRole});
			modelBuilder.Entity<User>().HasData(new User[] {adminUser});
			base.OnModelCreating(modelBuilder);
		}

		
	}
}
