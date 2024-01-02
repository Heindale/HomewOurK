using HomewOurK.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomewOurK.Persistence.Contexts
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() : base() { }
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

		public DbSet<Groups> Groups { get; set; }
		public DbSet<Homeworks> Homeworks { get; set; }
		public DbSet<Subjects> Subjects { get; set; }
		public DbSet<Teachers> Teachers { get; set; }
		public DbSet<Users> Users { get; set; }
		public DbSet<GroupsUsers> GroupsUsers { get; set; }
		public DbSet<Attachments> Attachments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=homewourktest1;Username=postgres;Password=admin");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Groups>()
				.HasMany(c => c.Users)
				.WithMany(s => s.Groups)
				.UsingEntity<GroupsUsers>();
		}
	}
}