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

		[HttpGet]
		[Route("GetHomeworks")]
		public IActionResult GetHomeworks(int id)
		{
			var homeworks = _homeworkService.GetHomeworksByGroupId(id);

			return Ok(homeworks);
		}

		[HttpGet]
		[Route("GetHomework")]
		public IActionResult GetHomework(int id, int subjectId, int groupId)
		{
			var homework = _homeworkService.GetHomeworkById(id, subjectId, groupId);

			if (homework != null)
				return Ok(homework);
			return NotFound();
		}
	}
}