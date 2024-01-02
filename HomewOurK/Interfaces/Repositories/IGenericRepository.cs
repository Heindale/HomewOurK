namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		IQueryable<T> Entities { get; }

		List<T> GetAll();
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}