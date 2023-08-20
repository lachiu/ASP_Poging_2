using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoorraadSysteem.Models
{
	public class VatPercentage
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int Percentage { get; set; }
		public ICollection<TicketsProducts> TicketsProducts { get; set; }
	}
}
