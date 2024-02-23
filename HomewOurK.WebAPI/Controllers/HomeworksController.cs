using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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

			if (homeworks.Any())
				return Ok(homeworks);
			return NotFound("No homeworks was found for the group with id = " + groupId);
		}

		[HttpGet("GetHomework")]
		public IActionResult GetHomework(int homeworkId, int subjectId, int groupId)
		{
			var homework = _homeworkService.GetHomeworkById(homeworkId, subjectId, groupId);

			if (homework != null)
				return Ok(homework);
			return NotFound($"The homework wasn't found");
		}

		[HttpPost]
		public IActionResult AddHomework(Homework homework)
		{
			homework.Id = 0;
			if (_homeworkService.CreateNewHomework(homework))
				return Ok(homework);
			return BadRequest("The homework has not been added");
		}

		[HttpPatch]
		public IActionResult UpdateHomework(Homework homework)
		{
			if (_homeworkService.UpdateHomework(homework))
				return Ok(homework);
			return BadRequest("The homework has not been updated");
		}

		[HttpDelete]
		public IActionResult DeleteHomework(Homework homework)
		{
			if (_homeworkService.DeleteHomework(homework))
				return Ok(homework);
			return BadRequest("The homework has not been deleted");
		}
	}
}