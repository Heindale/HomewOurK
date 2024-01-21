using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace HomewOurK.Persistence.Repositories
{
	public class GroupsUsersRepository : IGroupsUsersRepository
	{
		private readonly ApplicationContext _context;
		private readonly ILogger _logger;

		public GroupsUsersRepository(ApplicationContext context, ILogger logger) 
		{
			_context = context;
			_logger = logger;
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
				_logger.LogInformation(ex, "The element could not be added!");
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
				_logger.LogInformation(ex, "The element could not be deleted!");
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
				_logger.LogInformation(ex, "The element could not be updated!");
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