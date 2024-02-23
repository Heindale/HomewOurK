using HomewOurK.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeachersSubjectsController : ControllerBase
	{
		private readonly ITeacherService _teacherService;

		public TeachersSubjectsController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpPost]
		public IActionResult AddSubjectToTeacher(int teacherId, int groupId, int subjectId)
		{
			if (_teacherService.AddSubject(teacherId, groupId, subjectId))
				return Ok();
			return BadRequest();
		}

		[HttpDelete]
		public IActionResult DeleteSubjectFromTeacher(int teacherId, int groupId, int subjectId)
		{
			if (_teacherService.DeleteSubject(teacherId, groupId, subjectId))
				return Ok();
			return BadRequest();
		}
	}
}