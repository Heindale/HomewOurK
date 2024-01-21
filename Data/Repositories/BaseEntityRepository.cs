using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Domain.Common;
using Microsoft.Extensions.Logging;

namespace HomewOurK.Persistence.Repositories
{
	public class BaseEntityRepository<Entity> : IBaseEntityRepository<Entity> where Entity : BaseEntity
	{
		private readonly ApplicationContext _context;
		private readonly ILogger _logger;

        public BaseEntityRepository(ApplicationContext context, ILogger logger)
        {
            _context = context;
			_logger = logger;
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
				_logger.LogInformation(ex, "The element could not be added!");
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
				_logger.LogInformation(ex, "The element could not be deleted!");
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
				_logger.LogInformation(ex, "The element could not be updated!");
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