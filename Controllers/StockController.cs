using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.Controllers
{
	public class StockController : Controller
	{
		public IActionResult Index()
		{
			List<Stock> stocks = new List<Stock>();
			stocks.Add(new Stock() { Id = 1, ProductId = 1, LocationId = 1, Qty = 2 });
			stocks.Add(new Stock() { Id = 2, ProductId = 1, LocationId = 1, Qty = 2 });
			stocks.Add(new Stock() { Id = 3, ProductId = 1, LocationId = 1, Qty = 2 });
			stocks.Add(new Stock() { Id = 4, ProductId = 1, LocationId = 1, Qty = 2 });
			stocks.Add(new Stock() { Id = 5, ProductId = 1, LocationId = 1, Qty = 2 });
			return View(stocks);
		}
	}
}
