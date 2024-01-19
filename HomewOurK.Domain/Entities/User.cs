using HomewOurK.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Entities
{
    [Index(nameof(Email), nameof(Username), IsUnique = true)]
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

        public int GroupsCount { get; set; }

        public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        public List<Group> Groups { get; set; } = new List<Group>();
        public List<GroupsUsers> GroupsUsers { get; set; } = new List<GroupsUsers>();
    }
}