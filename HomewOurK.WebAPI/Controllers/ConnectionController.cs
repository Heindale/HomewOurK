using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConnectionController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetStatus()
		{
			return Ok();
		}
	}
}
