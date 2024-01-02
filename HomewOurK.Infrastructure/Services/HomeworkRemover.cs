using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Persistence.Repositories;

namespace HomewOurK.Infrastructure.Services
{
	public class HomeworkRemover : IHomeworkRemover
	{
		private readonly SubjectElementRepository<Homeworks> _homeworkRepository;

		public HomeworkRemover(SubjectElementRepository<Homeworks> homeworkRepository)
		{
			_homeworkRepository = homeworkRepository;
		}

		public void RemoveHomework()
		{
			TimeSpan timeOfDeletion = TimeSpan.FromDays(60);
			DateTime today = DateTime.Now;

			List<Homeworks> homeworks = _homeworkRepository
				.GetAll()
				.Where(x => x.Done == true)
				.ToList();

			foreach (Homeworks homework in homeworks)
			{
				if (today.CompareTo(homework.CompletedDate + timeOfDeletion) < 0)
				{
					_homeworkRepository.Delete(homework);
				}
			}
		}
	}
}