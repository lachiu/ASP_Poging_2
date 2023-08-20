using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace VoorraadSysteem.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(100)]
		public string Name { get; set; }

		[Display(Name = "Beschrijving")]
		public string Description { get; set; }
		
		[MaxLength(100)]
		public string Barcode { get; set; }		

		public ICollection<Stock> Stocks { get; set; }
		public ICollection<TicketsProducts> TicketsProducts { get; set; }
	}
}
