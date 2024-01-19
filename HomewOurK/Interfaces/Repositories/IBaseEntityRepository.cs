using HomewOurK.Domain.Common;

namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface IBaseEntityRepository<Entity> : IGenericRepository<Entity> where Entity : BaseEntity
	{
		Entity GetById(int id);
		void Delete(Entity entity);
	}
}