using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;

namespace HomewOurK.Infrastructure.Services
{
	public class GroupService : IGroupService
	{
		private readonly IBaseEntityRepository<Groups> _groupsRepository;

		public GroupService(IBaseEntityRepository<Groups> groupsRepository)
		{
			_groupsRepository = groupsRepository;
		}
		public void CreateNewGroup(Groups group)
		{
			_groupsRepository.Add(group);
		}

		public void DeleteGroupById(int groupId)
		{
			_groupsRepository.Delete(new Groups { Id = groupId });
		}

		public void ExcludeUser(int groupId, int userId)
		{
			throw new NotImplementedException();
		}

		public Groups GetGroupById(int groupId)
		{
			throw new NotImplementedException();
		}

		public List<Users> GetUsersByGroupId(int groupId)
		{
			throw new NotImplementedException();
		}

		public void InviteUser(int groupId, int userId)
		{
			throw new NotImplementedException();
		}

		public void UpdateGroup(Groups group)
		{
			throw new NotImplementedException();
		}
	}
}
