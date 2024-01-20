using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
    public interface ITeacherService
    {
        Teacher? GetTeacherById(int teacherId, int groupId);
        IEnumerable<Teacher> GetTeachersByGroupId(int groupId);
        bool AddTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);

        bool AddSubject(Teacher teacher, Subject subject);
        bool AddSubject(int teacherId, int groupId, int subjectId);
        bool DeleteSubject(Teacher teacher, Subject subject);
        bool DeleteSubject(int teacherId, int groupId, int subjectId);

        IEnumerable<Subject>? GetSubjectsByTeacherId(int teacherId, int groupId);
        IEnumerable<Subject>? GetSubjectsFromTeacher(Teacher teacher);
    }
}
