using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeachersController(ITeacherService teacherService) : ControllerBase
	{
		private readonly ITeacherService _teacherService = teacherService;

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