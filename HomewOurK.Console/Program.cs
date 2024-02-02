using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Persistence.Repositories;
using HomewOurK.WebAPI.Services;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomewOurKConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("HomewOurKConsole");
			Console.WriteLine();

			var Services = new ServiceCollection()
				.AddTransient<IHomeworkService, HomeworkService>()
				.AddTransient<ITeacherService, TeacherService>()
				.AddTransient<IBaseEntityRepository<Group>, BaseEntityRepository<Group>>()
				.AddTransient<IGroupElementRepository<Subject>, GroupElementRepository<Subject>>()
				.AddTransient<IGroupElementRepository<Teacher>, GroupElementRepository<Teacher>>()
				.AddTransient<IGroupElementRepository<Attachment>, GroupElementRepository<Attachment>>()
				.AddTransient<IGroupsUsersRepository, GroupsUsersRepository>()
				.AddTransient<ISubjectElementRepository<Homework>, SubjectElementRepository<Homework>>()
				.AddLogging()
				.AddDbContext<ApplicationContext>(options =>
				{
					options.UseNpgsql("Host=localhost;Port=5432;Database=homewourktest1;Username=postgres;Password=admin");
				});

			using var serviceProvider = Services.BuildServiceProvider();

			var _context = new ApplicationContext();

			ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
			ILogger logger = loggerFactory.CreateLogger<Program>();

			//var homeworksRepository = serviceProvider.GetRequiredService<ISubjectElementRepository<Homework>>();
			var homeworksRepository = new SubjectElementRepository<Homework>(_context, (ILogger<SubjectElementRepository<Homework>>)logger);
			var homeworkService = new HomeworkService(homeworksRepository);
			List<Homework> homeworks = homeworkService.GetHomeworksByGroupId(1).ToList();

			homeworkService.CreateNewHomework(new Homework
			{
				Deadline = DateTime.UtcNow + TimeSpan.FromDays(2),
				Description = "Сделать домашку",
				GroupId = 3,
				Importance = Importance.Written,
				SubjectId = 1,
			});

			Display.PrintHomeworks(homeworks);

			var teacherRepository = new GroupElementRepository<Teacher>(_context, (ILogger<GroupElementRepository<Teacher>>)logger);
			var subjectRepository = new GroupElementRepository<Subject>(_context, (ILogger<GroupElementRepository<Subject>>)logger);
			var teacherService = new TeacherService(teacherRepository, subjectRepository);

			Console.WriteLine("Объекты сохранены");

			Console.ReadLine();
		}
	}

	public static class Display
	{
		public static void PrintHomeworks(List<Homework> homeworks)
		{
			foreach (var item in homeworks)
			{
				Console.Write("Id: ");
				Console.WriteLine(item.Id);
				Console.Write("GroupId: ");
				Console.WriteLine(item.GroupId);
				Console.Write("Description: ");
				Console.WriteLine(item.Description);
				Console.Write("Deadline: ");
				Console.WriteLine(item.Deadline);
				Console.Write("CreationDate: ");
				Console.WriteLine(item.CreationDate);
				Console.Write("SubjectId: ");
				Console.WriteLine(item.SubjectId);
				Console.WriteLine("end");
				Console.WriteLine();
			}
		}
	}
}