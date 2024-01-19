using System.ComponentModel.DataAnnotations;
using HomewOurK.Domain.Common;

namespace HomewOurK.Domain.Entities
{
	public class Homework : SubjectElementEntity
	{
		[Required]
		[StringLength(100)]
		public string Description { get; set; } = "";

		public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
		
		public DateTime? CompletedDate { get; set; }

		public DateTime? Deadline { get; set; }

		public Importance Importance { get; set; } = Importance.Undefined;

		public bool Done { get; set; } = false;
	}
}