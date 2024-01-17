﻿using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface IUserService
	{
		Users GetUserById(int userId);
		List<Groups> GetGroupsByUserId(int userId);
		void RegisterNewUser(Users user);
		void UpdateUser(Users user);
		void DeleteUserById(int userId);
		void JoinGroup(int userId, int groupId);
		void LeaveGroup(int userId, int groupId);
	}
}
