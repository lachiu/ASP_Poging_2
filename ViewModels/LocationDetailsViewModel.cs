using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class LocationDetailsViewModel
	{
		public string Name { get; set; }
		public User User { get; set; }
		public ICollection<Stock> Stocks { get; set; }
	}
}
