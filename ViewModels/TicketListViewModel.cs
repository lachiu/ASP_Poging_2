using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class TicketListViewModel
	{
		public string StoreSearch { get; set; }
		public List<Ticket> Tickets { get; set; }
	}
}
