using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface ITeacherRepository : IGroupElementRepository<Teacher>
	{
		public bool DeleteSubjectFromTeacher(int teacherId, int groupId, int subjectId);
	}
}