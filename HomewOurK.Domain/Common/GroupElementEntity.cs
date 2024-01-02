using HomewOurK.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using HomewOurK.Domain.Common.Interfaces;

namespace HomewOurK.Domain.Common
{
	[PrimaryKey(nameof(Id), nameof(GroupId))]
	public class GroupElementEntity : IGroupElementEntity
	{
		[Required]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[Required]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int GroupId { get; set; }
		public Groups? Group { get; set; }
	}
}