using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectsController(ISubjectService subjectService) : ControllerBase
	{
		private readonly ISubjectService _subjectService = subjectService;

		[HttpGet("GetSubjects")]
		public IActionResult GetSubjects(int groupId)
		{
			var subjects = _subjectService.GetSubjectsByGroupId(groupId);

			if (subjects.Any())
				return Ok(subjects);
			return NotFound("No subjects was found for the group with id = " + groupId);
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