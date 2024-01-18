using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Common;
using HomewOurK.Persistence.Contexts;

namespace HomewOurK.Persistence.Repositories
{
	public class GroupElementRepository<Entity> : IGroupElementRepository<Entity> where Entity : GroupElementEntity
	{
		private readonly ApplicationContext _context;

		public GroupElementRepository(ApplicationContext context)
		{
			_context = context;
		}

		public IQueryable<Entity> Entities => _context.Set<Entity>();

		public void Add(Entity entity)
		{
			var lastEntity = _context.Set<Entity>().OrderBy(x => x.Id)
							.LastOrDefault(x => x.GroupId == entity.GroupId);

			if (lastEntity == null)
				entity.Id = 0;
			else
				entity.Id = lastEntity.Id + 1;

			_context.Set<Entity>().Add(entity);
			_context.SaveChanges();			
		}

		public void DeleteById(int id, int groupId)
		{
			var dbEntity = _context.Set<Entity>().FirstOrDefault(x => x.Id == id && x.GroupId == groupId);
			if (dbEntity == null)
				return; 
			_context.Set<Entity>().Remove(dbEntity);
			_context.SaveChanges();
		}

		public void Update(Entity entity)
		{
			var dbEntity = _context.Set<Entity>()
				.FirstOrDefault(x => x.Id == entity.Id && x.GroupId == entity.GroupId);
			if (dbEntity == null)
				return;
			_context.Set<Entity>().Update(entity);
			_context.SaveChanges();
		}

		public List<Entity> GetAll()
		{
			return _context.Set<Entity>().ToList();
		}

		public Entity GetById(int id, int groupId)
		{
			return (Entity)(_context.Set<Entity>().FirstOrDefault(x => x.Id == id && x.GroupId == groupId) 
				?? new GroupElementEntity());
		}
	}
}