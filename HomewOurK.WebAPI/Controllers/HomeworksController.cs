using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeworksController(IHomeworkService homeworkService) : ControllerBase
	{
		private readonly IHomeworkService _homeworkService = homeworkService;

		[HttpGet("GetHomeworks")]
		public IActionResult GetHomeworks(int groupId)
		{
			var homeworks = _homeworkService.GetHomeworksByGroupId(groupId);

			return Ok(homeworks);
		}

		[HttpGet("GetHomework")]
		public IActionResult GetHomework(int homeworkId, int subjectId, int groupId)
		{
			var homework = _homeworkService.GetHomeworkById(homeworkId, subjectId, groupId);

			if (homework != null)
				return Ok(homework);
			return NotFound();
		}
	}
}