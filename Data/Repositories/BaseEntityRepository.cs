using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Domain.Common;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HomewOurK.Domain.Common.Interfaces;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Persistence.Repositories
{
	public class BaseEntityRepository<Entity>(ApplicationContext context, ILogger<BaseEntityRepository<Entity>> logger) : IBaseEntityRepository<Entity> where Entity : BaseEntity
	{
		private readonly ApplicationContext _context = context;
		private readonly ILogger<BaseEntityRepository<Entity>> _logger = logger;

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
				var existingUser = _context.Set<Entity>().FirstOrDefault(u => u.Id == entity.Id);
				if (existingUser != null)
				{
					_context.Entry(existingUser).State = EntityState.Detached; // Отсоединяем существующий экземпляр
				}

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