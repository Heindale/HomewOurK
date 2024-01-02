using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
	public class Subjects : GroupElementEntity
	{
		[Required]
		[StringLength(50)]
		public string Name { get; set; } = "";

		public List<Teachers> Teachers { get; set; } = new List<Teachers>();
	}
}