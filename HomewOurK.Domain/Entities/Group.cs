using HomewOurK.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
	public class Group : BaseEntity
	{
		[Required]
		[StringLength(25)]
		public string Name { get; set; } = "";

		[Range(0, 99)]
		public int? Grade { get; set; }

		[StringLength(25)]
		public string? GroupType { get; set; }

		public List<User> Users { get; set; } = new List<User>();
		public List<GroupsUsers> GroupsUsers { get; set; } = new List<GroupsUsers>();
	}
}