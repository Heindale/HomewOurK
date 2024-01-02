using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Repositories;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.WebAPI.Services
{
	public class HomeworkService : IHomeworkService
	{
		private readonly SubjectElementRepository<Homeworks> _homeworkRepository;

		public HomeworkService(SubjectElementRepository<Homeworks> homeworkRepository) 
		{
			_homeworkRepository = homeworkRepository;
		}

		public void CreateNewHomework(Homeworks homework)
		{
			_homeworkRepository.Add(homework);
		}

		public void DeleteHomework(Homeworks homework)
		{
			_homeworkRepository.Delete(homework);
		}

		public void UpdateHomework(Homeworks homework)
		{
			_homeworkRepository.Update(homework);
		}

		public Homeworks GetHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			return _homeworkRepository.GetById(homeworkId, subjectId, groupId);
		}

		public List<Homeworks> GetHomeworksByGroupId(int groupId)
		{
			return _homeworkRepository.Entities.Where(x => x.GroupId == groupId).ToList();
		}
	}
}