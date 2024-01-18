using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IGroupService
	{
		Groups GetGroupById(int groupId);
		List<Groups> GetGroupsByUserId(int userId);
		void UpdateGroup(Groups group);
		void CreateNewGroup(Groups group);
		void DeleteGroupById(int groupId);

		void InviteUser(int groupId, int userId);
		void ExcludeUser(int groupId, int userId);
	}
}