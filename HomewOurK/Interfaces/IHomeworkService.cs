using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IHomeworkService
	{
		IEnumerable<Homework> GetHomeworksByGroupId(int groupId);
		IEnumerable<Homework> GetHomeworksBySubjectId(int subjectId, int groupId);
		Homework? GetHomeworkById(int homeworkId, int subjectId, int groupId);
		bool UpdateHomework(Homework homework);
		bool CreateNewHomework(Homework homework);
		bool CompleteHomework(Homework homework);
		bool DeleteHomework(Homework homework);
	}
}
