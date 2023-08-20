using System.Collections;
using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class StoreDetailsViewModel
	{
		public string Name { get; set; }
		public ICollection<Ticket> Tickets { get; set; }
	}
}
