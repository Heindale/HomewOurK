using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces.Repositories
{
	public interface IGroupsUsersRepository : IGenericRepository<GroupsUsers> 
	{
		GroupsUsers GetById(int groupId, int userId);
		void DeleteById(int groupId, int userId);
	}
}