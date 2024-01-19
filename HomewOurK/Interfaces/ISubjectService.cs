using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface ISubjectService
	{
		Subject GetSubjectById(int subjectId, int groupId);
		IEnumerable<Subject> GetSubjectsByGroupId(int groupId);
		bool AddSubject(Subject subject);
		bool UpdateSubject(Subject subject);
		bool DeleteSubject(Subject subject);

		bool AddTeacher(Subject subject, Teacher teacher);
		bool AddTeacher(int subjectId, int teacherId);
		bool DeleteTeacher(Subject subject, Teacher teacher);
		bool DeleteTeacher(int subjectId, int teacherId);

		IEnumerable<Teacher> GetTeachersBySubjectId(int subjectId, int groupId);
		IEnumerable<Teacher> GetTeachersFromSubject(int subjectId, int groupId);
	}
}
