using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IHomeworkService
	{
		List<Homeworks> GetHomeworksByGroupId(int groupId);
		Homeworks GetHomeworkById(int homeworkId, int subjectId, int groupId);
		void UpdateHomework(Homeworks homework);
		void CreateNewHomework(Homeworks homework);
		void DeleteHomework(Homeworks homework);
	}
}
