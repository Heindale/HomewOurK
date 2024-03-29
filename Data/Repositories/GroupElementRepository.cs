﻿using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Common;
using HomewOurK.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace HomewOurK.Persistence.Repositories
{
	public class GroupElementRepository<Entity>(ApplicationContext context, ILogger<GroupElementRepository<Entity>> logger) : IGroupElementRepository<Entity> where Entity : GroupElementEntity
	{
		private readonly ApplicationContext _context = context;
		private readonly ILogger<GroupElementRepository<Entity>> _logger = logger;

		public IQueryable<Entity> Entities => _context.Set<Entity>();

		public bool Add(Entity entity)
		{
			try
			{
				var lastEntity = _context.Set<Entity>()
						.Where(x => x.GroupId == entity.GroupId)
						.OrderBy(x => x.Id)
						.LastOrDefault();

				if (lastEntity == null)
					entity.Id = 0;
				else
					entity.Id = lastEntity.Id + 1;

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

		public Entity? GetById(int id, int groupId)
		{
			return _context.Set<Entity>()
				.FirstOrDefault(x => x.Id == id && x.GroupId == groupId);
		}
	}
}