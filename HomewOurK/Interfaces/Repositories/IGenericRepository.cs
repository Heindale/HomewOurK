namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		IQueryable<T> Entities { get; }

		IEnumerable<T> GetAll();
		bool Add(T entity);
		bool Update(T entity);
		bool Delete(T entity);
	}
}