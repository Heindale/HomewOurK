using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using HomewOurK.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class TeachersController : ControllerBase
	{
		private readonly ITeacherService _teacherService;
		private readonly ISubjectService _subjectService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserService _userService;

		public TeachersController(ITeacherService teacherService, ISubjectService subjectService, IHttpContextAccessor httpContextAccessor, IUserService userService)
		{
			_teacherService = teacherService;
			_subjectService = subjectService;
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
		}

		[HttpGet("GetTeachersBySubjectId")]
		public IActionResult GetTeachersBySubjectId(int subjectId, int groupId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);
			var teachers = _subjectService.GetTeachersBySubjectId(subjectId, groupId);

			if (_userService.UserInGroup(groupId, email))
			{
				if (teachers is not null && teachers.Any())
					return Ok(teachers);
				return NotFound("No teachers was found for the group with id = " + groupId);
			}
			return BadRequest("No teacher has been found for the current group");
		}

		[HttpGet("GetTeachers")]
		public IActionResult GetTeachers(int groupId)
		{
			var teachers = _teacherService.GetTeachersByGroupId(groupId);
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				if (teachers.Any())
					return Ok(teachers);
				return NotFound("No teachers was found for the group with id = " + groupId);
			}
			return BadRequest("No teacher has been found for the current group");
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