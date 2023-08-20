using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoorraadSysteem.Models
{
	public class Ticket
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Er moet een winkel geselecteerd zijn.")]
		[ForeignKey("Store")]
		public int StoreId { get; set; }

		[Display(Name = "Totaal")]
		public double? Total { get; set; }

		[Display(Name = "Aankoop datum")]
		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Er moet een aankoopdatum geselecteerd zijn.")]
		public DateTime PurchaseDate { get; set; }

		public virtual Store Store { get; set; }

		public string UserId { get; set; }

		public virtual User User { get; set; }

		public ICollection<TicketsProducts> TicketsProducts { get; set; }
	}
}
