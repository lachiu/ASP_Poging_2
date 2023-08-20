using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class TicketDetailsViewModel
	{
		public Store Store { get; set; }
		public double? Total { get; set; }
		public DateTime PurchaseDate { get; set; }
		public ICollection<TicketsProducts> TicketsProducts { get; set; }
	}
}
