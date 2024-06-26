﻿using HomewOurK.Domain.Entities;

namespace HomewOurK.WebAPI.Services.Interfaces
{
	public interface IGroupService
	{
		Group? GetGroupById(int groupId);

		IEnumerable<Group> GetAll();

		IEnumerable<Group> GetGroupsByUserId(int userId);

		IEnumerable<Group> GetGroupsWithoutUserId(int userId);

		GroupsUsers? GetGroupsUsers(int groupId, int userId);

		public bool UpdateGroupsUsers(GroupsUsers groupsUsers);

		bool UpdateGroup(Group group);

		bool CreateNewGroup(Group group);

		bool DeleteGroup(Group group);

		bool AddUserToGroup(Group group, User user);

		bool AddUserToGroup(GroupsUsers groupsUsers);

		bool DeleteUserFromGroup(Group group, User user);

		bool DeleteUserFromGroup(int groupId, int userId);
	}
}