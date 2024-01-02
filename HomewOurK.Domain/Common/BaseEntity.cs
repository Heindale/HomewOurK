using HomewOurK.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HomewOurK.Domain.Common
{
	public class BaseEntity : IEntity
	{
		[Key]
		public int Id { get; set; }
	}
}
