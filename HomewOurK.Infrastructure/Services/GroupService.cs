using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.Infrastructure.Services
{
	public class GroupService : IGroupService
	{
		private readonly IBaseEntityRepository<Group> _groupsRepository;

		private readonly IGroupsUsersRepository _groupsUsersRepository;

		public GroupService(IBaseEntityRepository<Group> groupsRepository, IGroupsUsersRepository groupsUsersRepository)
		{
			_groupsRepository = groupsRepository;
			_groupsUsersRepository = groupsUsersRepository;
		}

		public void CreateNewGroup(Group group)
		{
			_groupsRepository.Add(group);
		}

		public void DeleteGroupById(int groupId)
		{
			_groupsRepository.Delete(groupId);
		}

		public void ExcludeUser(int groupId, int userId)
		{
			_groupsUsersRepository.DeleteById(groupId, userId);
		}

		public Group GetGroupById(int groupId)
		{
			return _groupsRepository.GetById(groupId);
		}

		public List<Group> GetGroupsByUserId(int userId)
		{
			var groupsUsers = _groupsUsersRepository.Entities.Where(x => x.UserId == userId).ToList();
			List<Group> groups = new List<Group>();
			for (int i = 0; i < groupsUsers.Count; i++)
			{
				groups.Add(_groupsRepository.GetById(groupsUsers[i].GroupId));
			}
			return groups;
		}

		public void InviteUser(int groupId, int userId)
		{
			_groupsUsersRepository.Add(new GroupsUsers { GroupId = groupId, UserId = userId });
		}

		public void UpdateGroup(Group group)
		{
			_groupsRepository.Update(group);
		}
	}
}
