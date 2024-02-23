using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Repositories;

namespace HomewOurK.Infrastructure.Services
{
	public class AttachmentService : IAttachmentService
	{
		private readonly GroupElementRepository<Attachment> _attachmentRepository;

		public AttachmentService(GroupElementRepository<Attachment> attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public Attachment? GetAttachmentById(int attachmentId, int groupId)
		{
			return _attachmentRepository.GetById(attachmentId, groupId);
		}

		public IEnumerable<Attachment>? GetAttachmentsByGroupId(int groupId)
		{
			return _attachmentRepository.Entities.Where(x => x.GroupId == groupId);
		}

		public bool CreateNewAttachment(Attachment attachment)
		{
			return _attachmentRepository.Add(attachment);
		}

		public bool DeleteAttachmentById(Attachment attachment)
		{
			return _attachmentRepository.Delete(attachment);
		}

		public bool UpdateAttachment(Attachment attachment)
		{
			return _attachmentRepository.Update(attachment);
		}
	}
}