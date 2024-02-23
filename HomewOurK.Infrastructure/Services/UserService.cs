using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Infrastructure.Services
{
	public class UserService(IBaseEntityRepository<User> usersRepository, IGroupsUsersRepository groupsUsersRepository) : IUserService
	{
		private readonly IGroupsUsersRepository _groupsUsersRepository = groupsUsersRepository;
		private readonly IBaseEntityRepository<User> _usersRepository = usersRepository;

		public bool AddUser(User user)
		{
			var password = user.Password;
			return _usersRepository.Add(user);
		}

		public bool DeleteUser(User user)
		{
			return _usersRepository.Delete(user);
		}

		public User? GetUserById(int userId)
		{
			var user = _usersRepository.GetById(userId);
			if (user is not null)
				user.Password = null;
			return user;
		}

		public IEnumerable<User> GetAll()
		{
			var users = _usersRepository.GetAll();
			foreach (var user in users)
			{
				user.Password = null;
			}
			return users;
		}

		public bool UpdateUser(User user)
		{
			return _usersRepository.Update(user);
		}

		public bool AddUserToGroup(User user, Group group)
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

		public bool AddUserToGroup(int userId, int groupId)
		{
			return _groupsUsersRepository.Add(new GroupsUsers { GroupId = groupId, UserId = userId });
		}

		public IEnumerable<User> GetUsersByGroupId(int groupId)
		{
			var groupsUsers = _groupsUsersRepository.Entities.Where(x => x.GroupId == groupId).ToList();
			List<User> users = [];
			for (int i = 0; i < groupsUsers.Count; i++)
			{
				var newUser = _usersRepository.GetById(groupsUsers[i].UserId);
				if (newUser is not null)
				{
					newUser.Password = null;
					users.Add(newUser);
				}
			}
			return users;
		}

		public bool RemoveUserFromGroup(User user, Group group)
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

		public bool RemoveUserFromGroup(int userId, int groupId)
		{
			return _groupsUsersRepository.Delete(new GroupsUsers { GroupId = groupId, UserId = userId });
		}
	}
}