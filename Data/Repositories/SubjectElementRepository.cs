﻿using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Common;
using HomewOurK.Persistence.Contexts;

namespace HomewOurK.Persistence.Repositories
{
	public class SubjectElementRepository<Entity> : ISubjectElementRepository<Entity> where Entity : SubjectElementEntity
	{
		private readonly ApplicationContext _context;

		public SubjectElementRepository(ApplicationContext context)
		{
			_context = context;
		}

		public IQueryable<Entity> Entities => _context.Set<Entity>();

		public void Add(Entity entity)
		{
			var lastEntity = _context.Set<Entity>()
				.Where(x => x.GroupId == entity.GroupId && x.SubjectId == entity.SubjectId)
				.OrderBy(x => x.Id)
				.LastOrDefault();

			if (lastEntity == null)
			{
				entity.Id = 0;
			}
			else
			{
				entity.Id = lastEntity.Id + 1;
			}

			_context.Set<Entity>().Add(entity);
			_context.SaveChanges();
		}

		public void DeleteById(int id, int subjectId, int groupId)
		{
			var dbEntity = _context.Set<Entity>()
				.FirstOrDefault(x => x.Id == id && x.GroupId == groupId && x.SubjectId == subjectId);
			if (dbEntity == null)
				return;
			_context.Remove(dbEntity);
			_context.SaveChanges();
		}

		public void Update(Entity entity)
		{
			var dbEntity = _context.Set<Entity>()
				.FirstOrDefault(x => x.Id == entity.Id && x.GroupId == entity.GroupId && x.SubjectId == entity.SubjectId);
			if (dbEntity == null)
				return;
			_context.Set<Entity>().Update(entity);
			_context.SaveChanges();
		}

		public List<Entity> GetAll()
		{
			return _context.Set<Entity>().ToList();
		}

		public Entity GetById(int id, int subjectId, int groupId)
		{
			return (Entity)(_context.Set<Entity>().FirstOrDefault(x => x.Id == id
			&& x.SubjectId == subjectId && x.GroupId == groupId)
				?? new SubjectElementEntity());
		}
	}
}