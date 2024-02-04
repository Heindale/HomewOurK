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
		public IActionResult GetGroup(int groupId)
		{
			var group = _groupService.GetGroupById(groupId);

			if (group != null)
				return Ok(group);
			return NotFound();
		}
	}
}