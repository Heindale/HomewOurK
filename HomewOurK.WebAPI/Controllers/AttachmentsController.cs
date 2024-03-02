using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AttachmentsController : ControllerBase
	{
		private readonly IAttachmentService _attachmentService;
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AttachmentsController(IAttachmentService attachmentService, IHttpContextAccessor httpContextAccessor, IUserService userService)
		{
			_attachmentService = attachmentService;
			_httpContextAccessor = httpContextAccessor;
			_userService = userService;
		}

		[HttpGet("GetAttachments")]
		public IActionResult GetAttachments(int groupId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				var attachments = _attachmentService.GetAttachmentsByGroupId(groupId);

				if (attachments.Any())
					return Ok(attachments);
				return NotFound("No attachments was found for the group with id = " + groupId);
			}
			return Unauthorized();
		}

		[HttpGet("GetAttachment")]
		public IActionResult GetAttachment(int attachmentId, int groupId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				var attachment = _attachmentService.GetAttachmentById(attachmentId, groupId);

				if (attachment != null)
					return Ok(attachment);
				return NotFound($"The attachment wasn't found");
			}
			return Unauthorized();
		}

		[HttpPost]
		public IActionResult AddAttachment(Attachment attachment)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(attachment.GroupId, email))
			{
				attachment.Id = 0;
				if (_attachmentService.CreateNewAttachment(attachment))
					return Ok(attachment);
				return BadRequest("The attachment has not been added");
			}
			return Unauthorized();
		}

		[HttpPatch]
		public IActionResult UpdateAttachment(Attachment attachment)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(attachment.GroupId, email))
			{
				if (_attachmentService.UpdateAttachment(attachment))
					return Ok(attachment);
				return BadRequest("The attachment has not been updated");
			}
			return Unauthorized();
		}

		[HttpDelete]
		public IActionResult DeleteAttachment(int attachmentId, int groupId)
		{
			var email = CookieHelper.GetEmailByCookie(_httpContextAccessor);

			if (_userService.UserInGroup(groupId, email))
			{
				var attachment = new Attachment
				{
					GroupId = groupId,
					Id = attachmentId
				};

				if (_attachmentService.DeleteAttachmentById(attachment))
					return Ok(attachment);
				return BadRequest("The attachment has not been deleted");
			}
			return Unauthorized();
		}
	}
}