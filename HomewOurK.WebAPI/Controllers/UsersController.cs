using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
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

		[HttpPost("Register")]
		[AllowAnonymous]
		public IActionResult AddUser(User user)
		{
			user.Id = 0;
			if (_userService.AddUser(user))
				return Ok(user);
			return BadRequest("A user with this email already exists");
		}

		[HttpPost("Login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login(User user)
		{
			if (_userService.IsValidUser(user))
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Email, user.Email)
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				var authProperties = new AuthenticationProperties
				{
					IsPersistent = true
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

				return Ok();
			}
			return BadRequest();
		}

		[HttpPatch]
		public IActionResult UpdateUser(User user)
		{
			if (_userService.UpdateUser(user))
			{
				user.Password = null;
				return Ok(user);
			}
			return BadRequest();
		}

		[HttpDelete]
		public IActionResult DeleteUser(User user)
		{
			if (_userService.DeleteUser(user))
			{
				user.Password = null;
				return Ok(user);
			}
			return BadRequest();
		}
	}
}