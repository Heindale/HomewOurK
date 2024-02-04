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
		public IEnumerable<Homework> GetHomeworks(int id)
		{
			return _homeworkService.GetHomeworksByGroupId(id);
		}

		[HttpGet]
		public Homework GetHomework(int id, int subjectId, int groupId)
		{
			return _homeworkService.GetHomeworkById(id, subjectId, groupId) ?? new Homework();
		}
	}
}