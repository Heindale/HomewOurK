using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
	public class Attachments : GroupElementEntity
	{
		[MaxLength(100)]
		public string Name { get; set; } = "";

		public string Link { get; set; } = "";

		public int SubjectId { get; set; }
		public Subjects? Subject { get; set; }
	}
}
