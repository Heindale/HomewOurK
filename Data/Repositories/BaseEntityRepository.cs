using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Domain.Common;
using System.Collections.Generic;
using HomewOurK.Application.Interfaces;

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

		public void Add(Entity entity)
		{
			_context.Set<Entity>().Add(entity);
			_context.SaveChanges();
		}

		public void Delete(int Id)
		{
			var dbEntity = _context.Set<Entity>().FirstOrDefault(x => x.Id == Id);
			if (dbEntity == null)
				return;
			_context.Set<Entity>().Remove(dbEntity);
			_context.SaveChanges();
		}
		
		public void Update(Entity entity)
		{
			var dbEntity = _context.Set<Entity>().FirstOrDefault(x => x.Id == entity.Id);
			if (dbEntity == null)
				return;
			_context.Set<Entity>().Update(entity);
			_context.SaveChanges();
		}

		public List<Entity> GetAll()
		{
			return _context.Set<Entity>().ToList();
		}

		public Entity GetById(int id)
		{
			return (Entity)(_context.Set<Entity>().FirstOrDefault(x => x.Id == id) 
				?? new BaseEntity());
		}
	}
}