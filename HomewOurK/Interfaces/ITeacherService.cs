using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
    public interface ITeacherService
    {
        Teachers GetTeacherById(int teacherId, int groupId);
        List<Teachers> GetTeachersByGroupId(int groupId);
        void AddTeacher(Teachers teacher);
        void UpdateTeacher(Teachers teacher);
        void DeleteTeacherById(int teacherId, int groupId);
        void AddSubject(int teacherId, int subjectId);
        Subjects GetSubjectByTeacherId(int teacherId, int groupId);
    }
}