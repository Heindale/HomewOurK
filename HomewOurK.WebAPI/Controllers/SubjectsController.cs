using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using HomewOurK.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class SubjectsController : ControllerBase
	{
		private readonly ISubjectService _subjectService;
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public SubjectsController(ISubjectService subjectService, IUserService userService, IHttpContextAccessor httpContextAccessor)
		{
			_subjectService = subjectService;
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
		}

		[HttpGet("GetSubjects")]
		public IActionResult GetSubjects(int groupId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				var subjects = _subjectService.GetSubjectsByGroupId(groupId);

				if (subjects.Any())
					return Ok(subjects);
				return NotFound("No subjects was found for the group with id = " + groupId);
			}
			return BadRequest();
		}

		[HttpGet("GetSubject")]
		public IActionResult GetSubject(int subjectId, int groupId)
		{
			var subject = _subjectService.GetSubjectById(subjectId, groupId);

			if (subject != null)
				return Ok(subject);
			return NotFound($"The subject wasn't found");
		}

		[HttpPost]
		public IActionResult AddSubject(Subject subject)
		{
			subject.Id = 0;
			if (_subjectService.AddSubject(subject))
				return Ok(subject);
			return BadRequest("The subject has not been added");
		}

		[HttpPatch]
		public IActionResult UpdateSubject(Subject subject)
		{
			if (_subjectService.UpdateSubject(subject))
				return Ok(subject);
			return BadRequest("The subject has not been updated");
		}

		[HttpDelete]
		public IActionResult DeleteSubject(Subject subject)
		{
			if (_subjectService.DeleteSubject(subject))
				return Ok(subject);
			return BadRequest("The subject has not been deleted");
		}
	}
}