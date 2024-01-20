using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;

namespace HomewOurK.Persistence.Repositories
{
	public class GroupsUsersRepository : IGroupsUsersRepository
	{
		private readonly ApplicationContext _context;

		public GroupsUsersRepository(ApplicationContext context) 
		{
			_context = context;
		}

		public IQueryable<GroupsUsers> Entities => _context.GroupsUsers;

		public bool Add(GroupsUsers groupsUsers)
		{
			try
			{
				_context.GroupsUsers.Add(groupsUsers);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool Delete(GroupsUsers groupsUsers)
		{
			try
			{
				if (_context.GroupsUsers.Find(groupsUsers) == null)
					return false;
				_context.GroupsUsers.Remove(groupsUsers);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool Update(GroupsUsers groupsUsers)
		{
			try
			{
				if (_context.GroupsUsers.Find(groupsUsers) == null)
					return false;
				_context.GroupsUsers.Update(groupsUsers);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public IEnumerable<GroupsUsers> GetAll()
		{
			return _context.GroupsUsers.ToList();
		}

		public GroupsUsers? GetById(int groupId, int userId)
		{
			return _context.GroupsUsers.Find(groupId, userId);
		}
	}
}