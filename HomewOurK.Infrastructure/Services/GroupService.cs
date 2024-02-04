using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.Infrastructure.Services
{
	public class GroupService(IBaseEntityRepository<Group> groupsRepository, IGroupsUsersRepository groupsUsersRepository) : IGroupService
	{
		private readonly IBaseEntityRepository<Group> _groupsRepository = groupsRepository;
		private readonly IGroupsUsersRepository _groupsUsersRepository = groupsUsersRepository;

		public bool AddUserToGroup(Group group, User user)
		{
			var groupsUsers = new GroupsUsers
			{
				Group = group,
				GroupId = group.Id,
				User = user,
				UserId = user.Id
			};

			return _groupsUsersRepository.Add(groupsUsers);
		}

		public bool AddUserToGroup(int groupId, int userId)
		{
			return _groupsUsersRepository.Add(new GroupsUsers { GroupId = groupId, UserId = userId });
		}

		public bool CreateNewGroup(Group group)
		{
			return _groupsRepository.Add(group);
		}

		public bool DeleteGroup(Group group)
		{
			return _groupsRepository.Delete(group);
		}

		public bool DeleteUserFromGroup(Group group, User user)
		{
			var groupsUsers = new GroupsUsers
			{
				Group = group,
				GroupId = group.Id,
				User = user,
				UserId = user.Id
			};

			return _groupsUsersRepository.Delete(groupsUsers);
		}

		public bool DeleteUserFromGroup(int groupId, int userId)
		{
			return _groupsUsersRepository.Delete(new GroupsUsers { GroupId = groupId, UserId = userId });
		}

		public Group? GetGroupById(int groupId)
		{
			return _groupsRepository.GetById(groupId);
		}

		public IEnumerable<Group> GetAll()
		{
			return _groupsRepository.GetAll();
		}

		public IEnumerable<Group> GetGroupsByUserId(int userId)
		{
			var groupsUsers = _groupsUsersRepository.Entities.Where(x => x.UserId == userId).ToList();
			List<Group> groups = [];
			for (int i = 0; i < groupsUsers.Count; i++)
			{
				var newGroup = _groupsRepository.GetById(groupsUsers[i].GroupId);
				if (newGroup is not null)
					groups.Add(newGroup);
			}
			return groups;
		}

		public bool UpdateGroup(Group group)
		{
			return _groupsRepository.Update(group);
		}
	}
}