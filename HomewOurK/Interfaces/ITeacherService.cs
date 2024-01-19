using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
    public interface ITeacherService
    {
        Teachers GetTeacherById(int teacherId, int groupId);
        List<Teachers> GetTeachersByGroupId(int groupId);
        void AddTeacher(Teachers teacher);
        void UpdateTeacher(Teachers teacher);
        void DeleteTeacher(Teachers teacher);

        void AddSubject(int teacherId, int groupId, int subjectId);
        void DeleteSubjectById(int teacherId, int groupId, int subjectId);
        List<Subjects> GetSubjectsByTeacherId(int teacherId, int groupId);
    }
}