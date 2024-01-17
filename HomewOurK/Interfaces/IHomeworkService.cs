using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IHomeworkService
	{
		List<Homeworks> GetHomeworksByGroupId(int groupId);
		List<Homeworks> GetHomeworksBySubjectId(int groupId);
		Homeworks GetHomeworkById(int subjectId, int groupId);
		void UpdateHomework(Homeworks homework);
		void CreateNewHomework(Homeworks homework);
		void CompleteHomeworkById(int homeworkId, int subjectId, int groupId);
		void DeleteHomeworkById(int homeworkId, int subjectId, int groupId);
	}
}