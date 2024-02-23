using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttachmentsController : ControllerBase
	{
		private readonly IAttachmentService _attachmentService;

		public AttachmentsController(IAttachmentService attachmentService)
		{
			_attachmentService = attachmentService;
		}

		[HttpGet("GetAttachments")]
		public IActionResult GetAttachments(int groupId)
		{
			var attachments = _attachmentService.GetAttachmentsByGroupId(groupId);

			if (attachments.Any())
				return Ok(attachments);
			return NotFound("No attachments was found for the group with id = " + groupId);
		}

		[HttpGet("GetAttachment")]
		public IActionResult GetAttachment(int attachmentId, int groupId)
		{
			var attachment = _attachmentService.GetAttachmentById(attachmentId, groupId);

			if (attachment != null)
				return Ok(attachment);
			return NotFound($"The attachment wasn't found");
		}

		[HttpPost]
		public IActionResult AddAttachment(Attachment attachment)
		{
			attachment.Id = 0;
			if (_attachmentService.CreateNewAttachment(attachment))
				return Ok(attachment);
			return BadRequest("The attachment has not been added");
		}

		[HttpPatch]
		public IActionResult UpdateAttachment(Attachment attachment)
		{
			if (_attachmentService.UpdateAttachment(attachment))
				return Ok(attachment);
			return BadRequest("The attachment has not been updated");
		}

		[HttpDelete]
		public IActionResult DeleteAttachment(Attachment attachment)
		{
			if (_attachmentService.DeleteAttachmentById(attachment))
				return Ok(attachment);
			return BadRequest("The attachment has not been deleted");
		}
	}
}