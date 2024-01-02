using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Common;
using HomewOurK.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HomewOurK.Persistence.Repositories
{
	public class AsyncGenericRepository<T> : IAsyncGenericRepository<T> where T : BaseEntity
	{
		private readonly ApplicationContext _dbContext;

		public AsyncGenericRepository(ApplicationContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<T> Entities => _dbContext.Set<T>();

		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			return entity;
		}

		public Task UpdateAsync(T entity)
		{
			T exist = _dbContext.Set<T>().Find(entity.Id) ?? throw new Exception("The Entity was not found");
			_dbContext.Entry(exist).CurrentValues.SetValues(entity);
			return Task.CompletedTask;
		}

		public Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			return Task.CompletedTask;
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbContext
				.Set<T>()
				.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id) ?? throw new Exception("The Entity was not found");
		}
	}
}
