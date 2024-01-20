using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Domain.Common;

namespace HomewOurK.Persistence.Repositories
{
	// добавить обработчики ошибок
	// удаление объекта целиком
	// as Entity
	// возвращать null
	// IQueryable вместо списка(List)
	// IEnumerable<Entity> вместо конкретной коллекции List<Entity>
	public class BaseEntityRepository<Entity> : IBaseEntityRepository<Entity> where Entity : BaseEntity
	{
		private readonly ApplicationContext _context;

        public BaseEntityRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Entity> Entities => _context.Set<Entity>();

		public bool Add(Entity entity)
		{
			try
			{
				_context.Set<Entity>().Add(entity);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex) 
			{
				return false;
			}
		}

		public bool Delete(Entity entity)
		{
			try
			{
				if (_context.Set<Entity>().Find(entity) == null)
					return false;

				_context.Set<Entity>().Remove(entity);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		
		public bool Update(Entity entity)
		{
			try
			{
				_context.Set<Entity>().Update(entity);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public IEnumerable<Entity> GetAll()
		{
			return _context.Set<Entity>();
		}

		public Entity? GetById(int id)
		{
			return _context.Set<Entity>().Find(id);
		}
	}
}