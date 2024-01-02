using Microsoft.EntityFrameworkCore;

namespace HomewOurK.Domain.Entities
{
	[PrimaryKey(nameof(GroupId), nameof(UserId))]
	public class GroupsUsers
	{
		public int GroupId { get; set; }
		public Groups? Group { get; set; }

		public int UserId { get; set; }
		public Users? User { get; set; }

		public int UserLevel { get; set; }

		public int UserExperience { get; set; }

		public int CompletedHomeworksCount { get; set; }

		public int CreatedHomeworksCount { get; set; }
	}
}