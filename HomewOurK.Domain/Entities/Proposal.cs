using HomewOurK.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomewOurK.Domain.Entities
{
	public class Proposal : BaseEntity
	{
		[Required]
		public int UserId { get; set; }

		[JsonIgnore]
		public User? User { get; set; }

		[Required]
		public int GroupId { get; set; }

		[JsonIgnore]
		public Group? Group { get; set; }
	}
}
