using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
    public interface ITeacherService
    {
        Teacher GetTeacherById(int teacherId, int groupId);
        IEnumerable<Teacher> GetTeachersByGroupId(int groupId);
        bool AddTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);

        bool AddSubject(int teacherId, int groupId, int subjectId);
        bool DeleteSubjectById(int teacherId, int groupId, int subjectId);
        IEnumerable<Subject> GetSubjectsByTeacherId(int teacherId, int groupId);
    }
}
