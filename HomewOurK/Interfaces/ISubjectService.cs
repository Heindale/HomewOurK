using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface ISubjectService
	{
		Subject GetSubjectById(int subjectId, int groupId);
		List<Subject> GetSubjectsByGroupId(int groupId);
		void AddSubject(Subject subject);
		void UpdateSubject(Subject subject);
		void DeleteSubjectById(int subjectId, int groupId);

		void AddTeacher(int subjectId, int teacherId);
		void DeleteTeacher(int subjectId, int teacherId);
		List<Teacher> GetTeacherBySubjectId(int subjectId, int groupId);
	}
}
