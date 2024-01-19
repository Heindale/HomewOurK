using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface IUserService
	{
		User GetUserById(int userId);
		IEnumerable<User> GetUsersByGroupId(int groupId);
		bool AddUser(User user); // return true if user was added
		bool UpdateUser(User user); // return true if user was updated
		bool DeleteUser(User user); // return true if user was deleted

		bool AddUserToGroup(User user, Group group); // return true if user was added to group
		bool AddUserToGroup(int userId, int groupId); // return true if user was added to group
		bool RemoveUserFromGroup(User user, Group group); // return true if user was deleted from group
		bool RemoveUserFromGroup(int userId, int groupId); // return true if user was deleted from group
	}
}
