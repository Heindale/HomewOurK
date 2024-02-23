using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Infrastructure.Services
{
	public class AttachmentService : IAttachmentService
	{
		private readonly IGroupElementRepository<Attachment> _attachmentRepository;

		public AttachmentService(IGroupElementRepository<Attachment> attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public Attachment? GetAttachmentById(int attachmentId, int groupId)
		{
			return _attachmentRepository.GetById(attachmentId, groupId);
		}

		public IEnumerable<Attachment> GetAttachmentsByGroupId(int groupId)
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