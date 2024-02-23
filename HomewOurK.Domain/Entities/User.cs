using HomewOurK.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomewOurK.Domain.Entities
{
	[Index(nameof(Email), IsUnique = true)]
	public class User : BaseEntity
	{
		[Required]
		[EmailAddress]
		[StringLength(50)]
		public string Email { get; set; } = "";

		[Required]
		[StringLength(maximumLength: 25, MinimumLength = 3)]
		public string Username { get; set; } = "";

		[StringLength(maximumLength: 25, MinimumLength = 2)]
		public string? Firstname { get; set; }

		[StringLength(maximumLength: 25, MinimumLength = 2)]
		public string? Surname { get; set; }

		public string? Password { get; set; }

		public int GroupsCount { get; protected set; }

		public DateOnly RegistrationDate { get; protected set; } = DateOnly.FromDateTime(DateTime.UtcNow);

		[JsonIgnore]
		public List<Group> Groups { get; set; } = [];

		[JsonIgnore]
		public List<GroupsUsers> GroupsUsers { get; set; } = [];
	}
}