using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace HomewOurK.Domain.Entities
{
	[PrimaryKey(nameof(GroupId), nameof(UserId))]
	public class GroupsUsers
	{
		public int GroupId { get; set; }

		[JsonIgnore]
		public Group? Group { get; set; }

		public int UserId { get; set; }

		[JsonIgnore]
		public User? User { get; set; }

		public int UserLevel { get; set; }

		public int UserExperience { get; set; }

		public int CompletedHomeworksCount { get; set; }

		public int CreatedHomeworksCount { get; set; }
	}
}