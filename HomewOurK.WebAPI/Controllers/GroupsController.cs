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
			return Ok(_groupService.GetAll());
		}

		[HttpGet("GetGroups")]
		public IActionResult GetGroups(int userId)
		{
			var groups = _groupService.GetGroupsByUserId(userId);

			return Ok(groups);
		}

		[HttpGet("GetGroup")]
		public IActionResult GetGroup(int groupId)
		{
			var group = _groupService.GetGroupById(groupId);

			if (group != null)
				return Ok(group);
			return NotFound();
		}
	}
}