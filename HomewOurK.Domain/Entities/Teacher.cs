using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
	public class Teacher : GroupElementEntity
	{
		[Required]
		[StringLength(100)]
		public string FullName { get; set; } = "";

		public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}