using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController(IUserService userService) : ControllerBase
	{
		private readonly IUserService _userService = userService;

		[HttpGet]
		public IActionResult GetAll()
		{
			var users = _userService.GetAll();

			if (users.Any())
				return Ok(users);
			return NotFound("No users were found");
		}

		[HttpGet("GetUsers")]
		public IActionResult GetUsers(int groupId)
		{
			var users = _userService.GetUsersByGroupId(groupId);

			if (users.Any())
				return Ok(users);
			return NotFound("No users were found for the group with id = " + groupId);
		}

		[HttpGet("GetUser")]
		public IActionResult GetUser(int userId)
		{
			var users = _userService.GetUserById(userId);

			if (users != null)
				return Ok(users);
			return NotFound($"The user with id = {userId} wasn't found");
		}

		[HttpPost]
		public IActionResult AddUser(User user)
		{
			user.Id = 0;
			if (_userService.AddUser(user))
				return Ok(user);
			return BadRequest("A user with this email already exists");
		}

		[HttpPatch]
		public IActionResult UpdateUser(User user)
		{
			if (_userService.UpdateUser(user))
				return Ok(user);
			return BadRequest();
		}

		[HttpDelete]
		public IActionResult DeleteUser(User user)
		{
			if (_userService.DeleteUser(user))
				return Ok(user);
			return BadRequest();
		}
	}
}