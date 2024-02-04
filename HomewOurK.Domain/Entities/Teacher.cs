using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomewOurK.Domain.Entities
{
	public class Teacher : GroupElementEntity
	{
		[Required]
		[StringLength(100)]
		public string FullName { get; set; } = "";

		[JsonIgnore]
		public List<Subject> Subjects { get; set; } = [];
	}
}