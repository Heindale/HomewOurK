using HomewOurK.Domain.Common;

namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface ISubjectElementRepository<Entity> : IGenericRepository<Entity> where Entity : SubjectElementEntity
	{		
		Entity GetById(int id, int subjectId, int groupId);
		void DeleteById(int id, int subjectId, int groupId);
	}
}