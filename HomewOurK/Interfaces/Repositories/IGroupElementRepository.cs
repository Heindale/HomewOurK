using HomewOurK.Domain.Common;

namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface IGroupElementRepository<Entity> : IGenericRepository<Entity> where Entity : GroupElementEntity
	{
		Entity? GetById(int id, int groupId);
	}
}