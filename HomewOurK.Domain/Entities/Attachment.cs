using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomewOurK.Domain.Entities
{
	public class Attachment : GroupElementEntity
	{
		[MaxLength(100)]
		public string Name { get; set; } = "";

		public string Link { get; set; } = "";

		public int SubjectId { get; set; }

		[JsonIgnore]
		public Subject? Subject { get; set; }
	}
}