using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Helpers;
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
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UsersController(IUserService userService, IHttpContextAccessor httpContextAccessor)
		{
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
		}

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
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				var users = _userService.GetUsersByGroupId(groupId);

				if (users.Any())
				{
					foreach (var user in users)
						user.Password = null;
					return Ok(users);
				}
				return NotFound("No users were found for the group with id = " + groupId);
			}
			return BadRequest();
		}

		[HttpGet("GetUser")]
		public IActionResult GetUser()
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);
			var user = _userService.GetUserByEmail(email);

			if (user != null)
			{
				user.Password = null;
				return Ok(user);
			}
			return NotFound($"The user with email = {email} wasn't found");
		}

		[HttpPost("Register")]
		[AllowAnonymous]
		public IActionResult AddUser(User user)
		{
			user.Id = 0;
			if (_userService.AddUser(user))
			{
				user.Password = null;
				return Ok(user);
			}
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
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);
			var cookieUser = _userService.GetUserByEmail(email);

			if (cookieUser != null && cookieUser.Email != user.Email)
				return Unauthorized();

			if (user != null && cookieUser != null)
			{
				user.Id = cookieUser.Id;
				user.Email = cookieUser.Email;
				user.Password = cookieUser.Password;
				if (_userService.UpdateUser(user))
				{
					user.Password = null;
					return Ok(user);
				}
			}
			return BadRequest();
		}

		[HttpDelete]
		public IActionResult DeleteUser()
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);
			var user = _userService.GetUserByEmail(email);

			if (user != null)
				if (_userService.DeleteUser(user))
				{
					user.Password = null;
					return Ok(user);
				}
			return BadRequest();
		}
	}
}