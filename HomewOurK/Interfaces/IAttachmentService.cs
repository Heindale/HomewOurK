using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface IAttachmentService
	{
		List<Attachments> GetAttachmentsByGroupId(int groupId);
		Attachments GetAttachmentById(int attachmentId, int groupId);
		void CreateNewAttachment(Attachments attachment);
		void UpdateAttachment(Attachments attachment);
		void DeleteAttachmentById(int attachmentId);
	}
}
