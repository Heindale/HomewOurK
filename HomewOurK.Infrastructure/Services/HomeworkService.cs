using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.WebAPI.Services
{
	public class HomeworkService : IHomeworkService
	{
		private readonly ISubjectElementRepository<Homework> _homeworkRepository;

		public HomeworkService(ISubjectElementRepository<Homework> homeworkRepository) 
		{
			_homeworkRepository = homeworkRepository;
		}

		public bool CompleteHomework(Homework homework)
		{
			throw new NotImplementedException();
		}

		public bool CreateNewHomework(Homework homework)
		{
			throw new NotImplementedException();
		}

		public bool DeleteHomework(Homework homework)
		{
			throw new NotImplementedException();
		}

		public Homework GetHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Homework> GetHomeworksByGroupId(int groupId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Homework> GetHomeworksBySubjectId(int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public bool UpdateHomework(Homework homework)
		{
			throw new NotImplementedException();
		}
	}
}