using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Persistence.Repositories;
using HomewOurK.WebAPI.Services;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomewOurK.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddLogging();
			builder.Services.AddDbContext<ApplicationContext>(options =>
			options.UseNpgsql("Host=localhost;Port=5432;Database=homewourktest1;Username=postgres;Password=admin"));
			builder.Services.AddTransient<IHomeworkService, HomeworkService>()
				.AddTransient<ITeacherService, TeacherService>()
				.AddTransient<IBaseEntityRepository<Group>, BaseEntityRepository<Group>>()
				.AddTransient<IGroupElementRepository<Subject>, GroupElementRepository<Subject>>()
				.AddTransient<IGroupElementRepository<Teacher>, GroupElementRepository<Teacher>>()
				.AddTransient<IGroupElementRepository<Attachment>, GroupElementRepository<Attachment>>()
				.AddTransient<IGroupsUsersRepository, GroupsUsersRepository>()
				.AddTransient<ISubjectElementRepository<Homework>, SubjectElementRepository<Homework>>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}