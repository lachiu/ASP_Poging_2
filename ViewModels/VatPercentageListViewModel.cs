using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class VatPercentageListViewModel
	{
		public int VatPercentageSearch { get; set;  }
		public ICollection<VatPercentage> VatPercentages { get; set; }
	}
}
