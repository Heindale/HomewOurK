using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using HomewOurK.WebAPI.Helpers;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class UsersGroupsController : ControllerBase
	{
		private readonly IGroupService _groupService;

		public UsersGroupsController(IGroupService groupService)
		{
			_groupService = groupService;
		}

		[HttpGet("GetGroupsWithoutUser")]
		public IActionResult GetGroupsWithoutUser(int userId)
		{
			var groups = _groupService.GetGroupsWithoutUserId(userId);
			if (groups.Any())
				return Ok(groups);
			return BadRequest();
		}

		[HttpPost]
		public IActionResult AddUserToGroup(GroupsUsers groupsUsers)
		{
			if (_groupService.AddUserToGroup(groupsUsers))
				return Ok();
			return BadRequest();
		}

		[HttpDelete]
		public IActionResult DeleteUserFromGroup(int groupId, int userId)
		{
			if (_groupService.DeleteUserFromGroup(groupId, userId))
				return Ok();
			return BadRequest();
		}
	}
}