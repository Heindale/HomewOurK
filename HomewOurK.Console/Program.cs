using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Persistence.Repositories;
using HomewOurK.WebAPI.Services;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HomewOurKConsole
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("HomewOurKConsole");
            Console.WriteLine();

			var Services = new ServiceCollection()
				.AddTransient<IHomeworkService, HomeworkService>()
				.AddTransient<IBaseEntityRepository<Groups>, BaseEntityRepository<Groups>>()
				.AddTransient<IGroupElementRepository<Subjects>, GroupElementRepository<Subjects>>()
				.AddTransient<IGroupElementRepository<Teachers>, GroupElementRepository<Teachers>>()
				.AddTransient<IGroupElementRepository<Attachments>, GroupElementRepository<Attachments>>()
				.AddTransient<IGroupsUsersRepository, GroupsUsersRepository>()
				.AddTransient<ISubjectElementRepository<Homeworks>, SubjectElementRepository<Homeworks>>()
				.AddDbContext<ApplicationContext>(options =>
				{
					options.UseNpgsql("Host=localhost;Port=5432;Database=homewourktest1;Username=postgres;Password=admin");
				});


			using var serviceProvider = Services.BuildServiceProvider();

			var _context = new ApplicationContext();
			var homeworksRepository = new SubjectElementRepository<Homeworks>(_context);
			var homeworkService = new HomeworkService(homeworksRepository);

			List<Homeworks> homeworks = homeworkService.GetHomeworksByGroupId(1);

			homeworkService.CreateNewHomework(new Homeworks
			{
				Deadline = DateTime.UtcNow + TimeSpan.FromDays(2),
				Description = "Сделать домашку",
				GroupId = 1,
				Importance = Importance.Written,
				SubjectId = 1,				
			});

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

			Console.WriteLine("Объекты сохранены");


			Console.ReadLine();
		}
	}
}