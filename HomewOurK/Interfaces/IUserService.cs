using HomewOurK.Domain.Entities;
using System.Text.RegularExpressions;

namespace HomewOurK.Application.Interfaces
{
	public interface IUserService
	{
		Users GetUserById(int userId);
		IEnumerable<Users> GetUsersByGroupId(int groupId);
		bool RegisterNewUser(Users user); // return true if user was registered
		bool UpdateUser(Users user); // return true if user was updated
		bool DeleteUser(Users user); // return true if user was deleted

		bool AddUserToGroup(Users user, Group group); // return true if user was added to group
		bool AddUserToGroup(int userId, int groupId); // return true if user was added to group
		bool RemoveUserFromGroup(Users user, Group group); // return true if user was deleted from group
		bool RemoveUserFromGroup(int userId, int groupId); // return true if user was deleted from group
	}
}
