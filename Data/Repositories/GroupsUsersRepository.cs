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

		public virtual void Add(GroupsUsers groupsUsers)
		{
			_context.GroupsUsers.Add(groupsUsers);
			_context.SaveChanges();
		}

		public virtual void Delete(GroupsUsers groupsUsers)
		{
			_context.GroupsUsers.Remove(groupsUsers);
			_context.SaveChanges();
		}

		public virtual void Update(GroupsUsers groupsUsers)
		{
			_context.GroupsUsers.Update(groupsUsers);
			_context.SaveChanges();
		}

		public List<GroupsUsers> GetAll()
		{
			return _context.GroupsUsers.ToList();
		}

		public GroupsUsers GetById(int groupId, int userId)
		{
			return _context.GroupsUsers.FirstOrDefault(x => x.UserId == userId && x.GroupId == groupId)
				?? throw new Exception("The Entity was not found");
		}
	}
}