using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.Infrastructure.Services
{
	public class GroupService : IGroupService
	{
		private readonly IBaseEntityRepository<Groups> _groupsRepository;

		private readonly IGroupsUsersRepository _groupsUsersRepository;

		public GroupService(IBaseEntityRepository<Groups> groupsRepository, IGroupsUsersRepository groupsUsersRepository)
		{
			_groupsRepository = groupsRepository;
			_groupsUsersRepository = groupsUsersRepository;
		}

		public void CreateNewGroup(Groups group)
		{
			_groupsRepository.Add(group);
		}

		public void DeleteGroupById(int groupId)
		{
			_groupsRepository.DeleteById(groupId);
		}

		public void ExcludeUser(int groupId, int userId)
		{
			_groupsUsersRepository.DeleteById(groupId, userId);
		}

		public Groups GetGroupById(int groupId)
		{
			return _groupsRepository.GetById(groupId);
		}

		public List<Groups> GetGroupsByUserId(int userId)
		{
			var groupsUsers = _groupsUsersRepository.Entities.Where(x => x.UserId == userId).ToList();
			List<Groups> groups = new List<Groups>();
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

		public void UpdateGroup(Groups group)
		{
			_groupsRepository.Update(group);
		}
	}
}
