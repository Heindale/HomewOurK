using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Domain.Common;

namespace HomewOurK.Persistence.Repositories
{
	public class BaseEntityRepository<Entity> : IBaseEntityRepository<Entity> where Entity : BaseEntity
	{
		private readonly ApplicationContext _context;

        public BaseEntityRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Entity> Entities => _context.Set<Entity>();

		public void Add(Entity entity)
		{
			_context.Set<Entity>().Add(entity);
			_context.SaveChanges();
		}

		public void Delete(Entity entity)
		{
			_context.Set<Entity>().Remove(entity);
			_context.SaveChanges();
		}

		public void Update(Entity entity)
		{
			_context.Set<Entity>().Update(entity);
			_context.SaveChanges();
		}

		public List<Entity> GetAll()
		{
			return _context.Set<Entity>().ToList();
		}

		public Entity GetById(int id)
		{
			return _context.Set<Entity>().FirstOrDefault(x => x.Id == id) 
				?? throw new Exception("The Entity was not found");
		}
	}
}