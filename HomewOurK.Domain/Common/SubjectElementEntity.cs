using HomewOurK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HomewOurK.Domain.Common.Interfaces;

namespace HomewOurK.Domain.Common
{
	[PrimaryKey(nameof(Id), nameof(GroupId), nameof(SubjectId))]
	public class SubjectElementEntity : GroupElementEntity, ISubjectElementEntity
	{
		[Required]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SubjectId { get; set; }
		public Subject? Subject { get; set; }
	}
}