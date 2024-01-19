using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface IAttachmentService
	{
		List<Attachment> GetAttachmentsByGroupId(int groupId);
		Attachment GetAttachmentById(int attachmentId, int groupId);
		void CreateNewAttachment(Attachment attachment);
		void UpdateAttachment(Attachment attachment);
		void DeleteAttachmentById(int attachmentId);
	}
}
