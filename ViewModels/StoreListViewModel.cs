using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class StoreListViewModel
	{
		public string StoreSearch { get; set; }
		public List<Store> Stores { get; set; }
	}
}