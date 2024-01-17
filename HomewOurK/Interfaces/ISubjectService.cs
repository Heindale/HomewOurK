using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface ISubjectService
	{
		Subjects GetSubjectById(int subjectId, int groupId);
		List<Subjects> GetSubjectsByGroupId(int groupId);
		void AddSubject(Subjects subject);
		void UpdateSubject(Subjects subject);
		void DeleteSubjectById(int subjectId);
		void AddTeacher(int SubjectId, int TeacherId);
		void DeleteTeacher(int SubjectId, int TeacherId);
		List<Teachers> GetTeacherBySubjectId(int subjectId, int groupId);
	}
}
