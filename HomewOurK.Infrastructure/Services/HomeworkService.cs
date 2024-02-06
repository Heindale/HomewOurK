using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.WebAPI.Services
{
	public class HomeworkService(ISubjectElementRepository<Homework> homeworkRepository) : IHomeworkService
	{
		private readonly ISubjectElementRepository<Homework> _homeworkRepository = homeworkRepository;

		public bool CompleteHomework(Homework homework)
		{
			homework.Done = true;
			return _homeworkRepository.Update(homework);
		}

		public bool CreateNewHomework(Homework homework)
		{
			return _homeworkRepository.Add(homework);
		}

		public bool DeleteHomework(Homework homework)
		{
			return _homeworkRepository.Delete(homework);
		}

		public Homework? GetHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			return _homeworkRepository.GetById(homeworkId, subjectId, groupId);
		}

		public IEnumerable<Homework> GetHomeworksByGroupId(int groupId)
		{
			return _homeworkRepository.Entities.Where(e => e.GroupId == groupId);
		}

		public IEnumerable<Homework> GetHomeworksBySubjectId(int subjectId, int groupId)
		{
			return _homeworkRepository.Entities.Where(e => e.GroupId == groupId && e.SubjectId == subjectId);
		}

		public bool UpdateHomework(Homework homework)
		{
			return _homeworkRepository.Update(homework);
		}
	}
}