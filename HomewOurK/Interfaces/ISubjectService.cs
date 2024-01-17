using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface ISubjectService
	{
		Subjects GetSubjectById(int subjectId, int groupId);
		List<Subjects> GetSubjectsByGroupId(int groupId);
		void AddSubject(Subjects subject);
		void UpdateSubject(Subjects subject);
		void DeleteSubjectById(int subjectId, int groupId);

		void AddTeacher(int subjectId, int teacherId);
		void DeleteTeacher(int subjectId, int teacherId);
		List<Teachers> GetTeacherBySubjectId(int subjectId, int groupId);
	}
}
