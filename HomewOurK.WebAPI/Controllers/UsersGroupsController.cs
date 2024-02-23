using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersGroupsController : ControllerBase
	{
		private readonly IGroupService _groupService;

		public UsersGroupsController(IGroupService groupService)
		{
			_groupService = groupService;
		}

		[HttpPost]
		public IActionResult AddUserToGroup(int groupId, int userId)
		{
			if (_groupService.AddUserToGroup(groupId, userId))
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