using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface IAttachmentService
	{
		IEnumerable<Attachment> GetAttachmentsByGroupId(int groupId);
		Attachment GetAttachmentById(int attachmentId, int groupId);
		bool CreateNewAttachment(Attachment attachment);
		bool UpdateAttachment(Attachment attachment);
		bool DeleteAttachmentById(Attachment attachment);
	}
}
