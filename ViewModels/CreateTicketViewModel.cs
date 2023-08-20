using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class CreateTicketViewModel
	{
		public int StoreId { get; set; }
		public int UserId { get; set; }
		public double? Total { get; set; }
		public DateTime PurchaseDate { get; set; }
		public ICollection<Store> Stores { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}