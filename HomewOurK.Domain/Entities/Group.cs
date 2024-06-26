﻿using HomewOurK.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomewOurK.Domain.Entities
{
	public class Group : BaseEntity
	{
		[Required]
		[StringLength(25)]
		public string Name { get; set; } = "";

		[Required]
		[StringLength(50)]
		public string? UniqGroupName { get; set; }

		[Range(0, 99)]
		public int? Grade { get; set; }

		[StringLength(25)]
		public string? GroupType { get; set; }

		[JsonIgnore]
		public List<User> Users { get; set; } = [];
		[JsonIgnore]
		public List<GroupsUsers> GroupsUsers { get; set; } = [];
	}
}