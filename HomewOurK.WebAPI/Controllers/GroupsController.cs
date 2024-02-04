using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupsController(IGroupService groupService) : ControllerBase
	{
		private readonly IGroupService _groupService = groupService;

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
				return Ok();
			return BadRequest();
		}

		[HttpPatch]
		public IActionResult UpdateGroup(Group group)
		{
			if (_groupService.UpdateGroup(group))
				return Ok();
			return BadRequest();
		}
	}
}