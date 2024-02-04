using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IGroupService
	{
		Group? GetGroupById(int groupId);

		IEnumerable<Group> GetAll();

		IEnumerable<Group> GetGroupsByUserId(int userId);

		bool UpdateGroup(Group group);

		bool CreateNewGroup(Group group);

		bool DeleteGroup(Group group);

		bool AddUserToGroup(Group group, User user);

		bool AddUserToGroup(int groupId, int userId);

		bool DeleteUserFromGroup(Group group, User user);

		bool DeleteUserFromGroup(int groupId, int userId);
	}
}