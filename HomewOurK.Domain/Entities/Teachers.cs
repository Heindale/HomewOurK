using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
	public class Teachers : GroupElementEntity
	{
		[Required]
		[StringLength(100)]
		public string FullName { get; set; } = "";

		public List<Subjects> Subjects { get; set; } = new List<Subjects>();
    }
}