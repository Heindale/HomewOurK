using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IGroupService
	{
		Group GetGroupById(int groupId);
		List<Group> GetGroupsByUserId(int userId);
		void UpdateGroup(Group group);
		void CreateNewGroup(Group group);
		void DeleteGroupById(int groupId);

		void InviteUser(int groupId, int userId);
		void ExcludeUser(int groupId, int userId);
	}
}