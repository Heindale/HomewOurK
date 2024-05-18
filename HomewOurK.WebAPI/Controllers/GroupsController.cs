using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Helpers;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class GroupsController : ControllerBase
	{
		private readonly IGroupService _groupService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserService _userService;

		public GroupsController(IGroupService groupService, IHttpContextAccessor httpContextAccessor, IUserService userService)
		{
			_groupService = groupService;
			_httpContextAccessor = httpContextAccessor;
			_userService = userService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var groups = _groupService.GetAll();

			if (groups.Any())
				return Ok(groups);
			return NotFound("No groups were found");
		}

		[HttpGet("GetGroups")]
		public IActionResult GetGroups(int userId)
		{
			var groups = _groupService.GetGroupsByUserId(userId);

			if (groups.Any())
				return Ok(groups);
			return NotFound("No groups were found for the user with id = " + userId);
		}

		[HttpGet("GetGroup")]
		public IActionResult GetGroup(int groupId)
		{
			var group = _groupService.GetGroupById(groupId);

			if (group != null)
				return Ok(group);
			return NotFound($"The group with id = {groupId} wasn't found");
		}

		[HttpPost]
		public IActionResult AddGroup(Group group)
		{
			if (_groupService.CreateNewGroup(group))
			{
				var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);
				var user = _userService.GetUserByEmail(email);

				if (user != null)
					_groupService.AddUserToGroup(new GroupsUsers
					{
						User = user,
						UserId = user.Id,
						Group = group,
						GroupId = group.Id,
						Role = Role.GroupCreator
					});
				else
					return BadRequest("Current user is null");
				return Ok(group);
			}
			return BadRequest("The group hasn't added");
		}

		[HttpPatch]
		public IActionResult UpdateGroup(Group group)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(group.Id, email))
			{
				if (_groupService.UpdateGroup(group))
					return Ok(group);
				return BadRequest("The group hasn't updated");
			}
			return Unauthorized();
		}

		[HttpDelete]
		public IActionResult DeleteGroup(int groupId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				var group = new Group
				{
					Id = groupId,
					Name = "deleted group"
				};

				if (_groupService.DeleteGroup(group))
					return Ok(group);
				return BadRequest("The group hasn't deleted");
			}
			return Unauthorized();
		}
	}
}