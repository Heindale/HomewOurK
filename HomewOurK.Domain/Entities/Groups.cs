using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
	public class Groups : BaseEntity
	{
		[Required]
		[StringLength(25)]
		public string Name { get; set; } = "";

		[Range(0, 99)]
		public int? Grade { get; set; }

		[StringLength(25)]
		public string? GroupType { get; set; }

		public List<Users> Users { get; set; } = new List<Users>();
		public List<GroupsUsers> GroupsUsers { get; set; } = new List<GroupsUsers>();
	}
}