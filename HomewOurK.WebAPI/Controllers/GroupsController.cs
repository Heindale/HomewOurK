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
		[Route("GetGroup")]
		public IActionResult GetGroup(int id)
		{
			var group = _groupService.GetGroupById(id);

			if (group != null)
				return Ok(group);
			return NotFound();
		}
	}
}