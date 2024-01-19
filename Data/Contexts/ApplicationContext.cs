using HomewOurK.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomewOurK.Persistence.Contexts
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() : base() { }
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

		public DbSet<Group> Groups { get; set; }
		public DbSet<Homework> Homeworks { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<GroupsUsers> GroupsUsers { get; set; }
		public DbSet<Attachment> Attachments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=homewourktest1;Username=postgres;Password=admin");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Group>()
				.HasMany(c => c.Users)
				.WithMany(s => s.Groups)
				.UsingEntity<GroupsUsers>();
		}
	}
}