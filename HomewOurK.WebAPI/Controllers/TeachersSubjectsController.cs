using HomewOurK.Application.Interfaces;
using HomewOurK.Infrastructure.Services;
using HomewOurK.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class TeachersSubjectsController : ControllerBase
	{
		private readonly ITeacherService _teacherService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserService _userService;

		public TeachersSubjectsController(ITeacherService teacherService, IHttpContextAccessor httpContextAccessor, IUserService userService)
		{
			_teacherService = teacherService;
			_httpContextAccessor = httpContextAccessor;
			_userService = userService;
		}

		[HttpPost]
		public IActionResult AddSubjectToTeacher(int teacherId, int groupId, int subjectId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				if (_teacherService.AddSubject(teacherId, groupId, subjectId))
					return Ok();
				return BadRequest();
			}
			return Unauthorized();
		}

		[HttpDelete]
		public IActionResult DeleteSubjectFromTeacher(int teacherId, int groupId, int subjectId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				if (_teacherService.DeleteSubject(teacherId, groupId, subjectId))
					return Ok();
				return BadRequest();
			}
			return Unauthorized();
		}
	}
}