using System.Collections;
using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class LocationListViewModel
	{
		public string LocationSearch { get; set; }
		public ICollection<Location> Locations { get; set; }
	}
}
