using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeworksController : ControllerBase
	{
		private readonly IHomeworkService _homeworkService;
		public HomeworksController(IHomeworkService homeworkService)
		{
			_homeworkService = homeworkService;
		}
		[HttpGet]
		public IEnumerable<Homeworks> GetHomeworks(int id)
		{
			return _homeworkService.GetHomeworksByGroupId(id);
		}
		[HttpGet]
		public Homeworks GetHomework(int id, int subjectId, int groupId) 
		{
			return _homeworkService.GetHomeworkById(id, subjectId, groupId);
		}
	}
}
