﻿using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace HomewOurK.Persistence.Repositories
{
	public class GroupsUsersRepository(ApplicationContext context, ILogger<GroupsUsersRepository> logger) : IGroupsUsersRepository
	{
		private readonly ApplicationContext _context = context;
		private readonly ILogger<GroupsUsersRepository> _logger = logger;

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
			return _context.GroupsUsers;
		}

		public GroupsUsers? GetById(int groupId, int userId)
		{
			return _context.GroupsUsers
				.FirstOrDefault(x => x.GroupId == groupId && x.UserId == userId);
		}
	}
}