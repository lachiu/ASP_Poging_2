using System.Collections;
using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.ViewModels
{
	public class ProductListViewModel
	{
		public string ProductSearch { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
