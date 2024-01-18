using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Repositories;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.WebAPI.Services
{
	public class HomeworkService : IHomeworkService
	{
		private readonly ISubjectElementRepository<Homeworks> _homeworkRepository;

		public HomeworkService(ISubjectElementRepository<Homeworks> homeworkRepository) 
		{
			_homeworkRepository = homeworkRepository;
		}

		public void CompleteHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public void CreateNewHomework(Homeworks homework)
		{
			throw new NotImplementedException();
		}

		public void DeleteHomeworkById(int homeworkId, int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public Homeworks GetHomeworkById(int subjectId, int groupId)
		{
			throw new NotImplementedException();
		}

		public List<Homeworks> GetHomeworksByGroupId(int groupId)
		{
			throw new NotImplementedException();
		}

		public List<Homeworks> GetHomeworksBySubjectId(int groupId)
		{
			throw new NotImplementedException();
		}

		public void UpdateHomework(Homeworks homework)
		{
			throw new NotImplementedException();
		}
	}
}