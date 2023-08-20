using System;
using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.ViewModels
{
	public class UserDetailsViewModel
	{
		public string Name { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? CreatedAt { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? LastLogin { get; set; }
	}
}
