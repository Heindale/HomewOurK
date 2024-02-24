using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class TeachersController(ITeacherService teacherService, ISubjectService subjectService) : ControllerBase
	{
		private readonly ITeacherService _teacherService = teacherService;
		private readonly ISubjectService _subjectService = subjectService;

		[HttpGet("GetTeachersBySubjectId")]
		public IActionResult GetTeachersBySubjectId(int subjectId, int groupId)
		{
			var teachers = _subjectService.GetTeachersBySubjectId(subjectId, groupId);

			if (teachers is not null && teachers.Any())
				return Ok(teachers);
			return NotFound("No teachers was found for the group with id = " + groupId);
		}

		[HttpGet("GetTeachers")]
		public IActionResult GetTeachers(int groupId)
		{
			var teachers = _teacherService.GetTeachersByGroupId(groupId);

			if (teachers.Any())
				return Ok(teachers);
			return NotFound("No teachers was found for the group with id = " + groupId);
		}

		[HttpGet("GetTeacher")]
		public IActionResult GetTeacher(int teacherId, int groupId)
		{
			var teacher = _teacherService.GetTeacherById(teacherId, groupId);

			if (teacher != null)
				return Ok(teacher);
			return NotFound($"The teacher wasn't found");
		}

		[HttpPost]
		public IActionResult AddTeacher(Teacher teacher)
		{
			teacher.Id = 0;
			if (_teacherService.AddTeacher(teacher))
				return Ok(teacher);
			return BadRequest("The teacher has not been added");
		}

		[HttpPatch]
		public IActionResult UpdateTeacher(Teacher teacher)
		{
			if (_teacherService.UpdateTeacher(teacher))
				return Ok(teacher);
			return BadRequest("The teacher has not been updated");
		}

		[HttpDelete]
		public IActionResult DeleteTeacher(Teacher teacher)
		{
			if (_teacherService.DeleteTeacher(teacher))
				return Ok(teacher);
			return BadRequest("The teacher has not been deleted");
		}
	}
}