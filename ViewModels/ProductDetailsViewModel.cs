using System.Collections;
using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class ProductDetailsViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Barcode { get; set; }
		public ICollection<Stock> Stocks { get; set; }
		public ICollection<TicketsProducts> TicketsProducts { get; set; }
	}
}
