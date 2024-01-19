using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IHomeworkService
	{
		List<Homework> GetHomeworksByGroupId(int groupId);
		List<Homework> GetHomeworksBySubjectId(int groupId);
		Homework GetHomeworkById(int subjectId, int groupId);
		void UpdateHomework(Homework homework);
		void CreateNewHomework(Homework homework);
		void CompleteHomeworkById(int homeworkId, int subjectId, int groupId);
		void DeleteHomeworkById(int homeworkId, int subjectId, int groupId);
	}
}