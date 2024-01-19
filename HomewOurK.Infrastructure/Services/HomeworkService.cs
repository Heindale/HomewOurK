using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Repositories;
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

		public void CompleteHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public void CreateNewHomework(Homework homework)
		{
			throw new NotImplementedException();
		}

		public void DeleteHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public Homework GetHomeworkById(int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public List<Homework> GetHomeworksByGroupId(int groupId)
		{
			throw new NotImplementedException();
		}

		public List<Homework> GetHomeworksBySubjectId(int groupId)
		{
			throw new NotImplementedException();
		}

		public void UpdateHomework(Homework homework)
		{
			throw new NotImplementedException();
		}
	}
}