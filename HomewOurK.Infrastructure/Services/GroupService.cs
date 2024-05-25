using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Repositories;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.Infrastructure.Services
{
	public class GroupService : IGroupService
	{
		private readonly IBaseEntityRepository<Group> _groupsRepository;
		private readonly IBaseEntityRepository<User> _userRepository;
		private readonly IGroupsUsersRepository _groupsUsersRepository;

		public GroupService(IBaseEntityRepository<Group> groupsRepository, IGroupsUsersRepository groupsUsersRepository, IBaseEntityRepository<User> userRepository)
		{
			_groupsRepository = groupsRepository;
			_userRepository = userRepository;
			_groupsUsersRepository = groupsUsersRepository;
		}

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

		public bool AddUserToGroup(GroupsUsers groupsUsers)
		{
			//return _groupsUsersRepository.Add(new GroupsUsers { GroupId = groupId, UserId = userId });

			//var group = _groupsRepository.GetById(groupId);
			//var user = _userRepository.GetById(userId);

			//if (group != null && user != null)
			//{
			//	group.Users.Add(user);
			//	return _groupsRepository.Update(group);
			//}
			//return false;
			return _groupsUsersRepository.Add(groupsUsers);
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

		public IEnumerable<Group> GetGroupsWithoutUserId(int userId)
		{
			var groupsIdsByUser = _groupsUsersRepository.Entities.Where(x => x.UserId == userId).Select(x => x.GroupId).ToList();
			var allGroupsIds = _groupsRepository.Entities.Select(g => g.Id);
			var groupsIdsWithoutUser = allGroupsIds.Except(groupsIdsByUser).ToList();

			List<Group> groups = [];
			for (int i = 0; i < groupsIdsWithoutUser.Count; i++)
			{
				var newGroup = _groupsRepository.GetById(groupsIdsWithoutUser[i]);
				if (newGroup is not null)
					groups.Add(newGroup);
			}
			return groups;
		}

		public bool UpdateGroup(Group group)
		{
			return _groupsRepository.Update(group);
		}

		public GroupsUsers? GetGroupsUsers(int groupId, int userId)
		{
			return _groupsUsersRepository.GetById(groupId, userId);
		}

		public bool UpdateGroupsUsers(GroupsUsers groupsUsers)
		{
			return _groupsUsersRepository.Update(groupsUsers);
		}
	}
}