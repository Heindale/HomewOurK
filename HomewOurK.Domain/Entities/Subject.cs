using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomewOurK.Domain.Entities
{
	public class Subject : GroupElementEntity
	{
		[Required]
		[StringLength(50)]
		public string Name { get; set; } = "";

		[JsonIgnore]
		public List<Teacher> Teachers { get; set; } = new List<Teacher>();
	}
}